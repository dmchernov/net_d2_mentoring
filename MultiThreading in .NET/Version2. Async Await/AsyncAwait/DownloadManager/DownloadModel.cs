using DownloadManager.Annotations;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadManager
{
	public class DownloadModel : INotifyPropertyChanged
	{
		private ObservableCollection<Download> _dowloads = new ObservableCollection<Download>();
		private readonly IDictionary<Download, CancellationTokenSource> _cancellations = new ConcurrentDictionary<Download, CancellationTokenSource>();

		public ObservableCollection<Download> Downloads => _dowloads;

		public void Add(string uri, string caption, string fileName)
		{
			var localFileName = Path.Combine(Directory.GetCurrentDirectory(), "tmp", fileName);
			var download = new Download
			{
				Caption = caption,
				Uri = new Uri(uri),
				LocalFileName = localFileName
			};

			_dowloads.Add(download);
			download.PropertyChanged += PropertyChanged;
		}

		public async void DeleteAsync(Download download)
		{
			await Task.Factory.StartNew(() =>
			{
				if (_cancellations.Keys.Contains(download))
				{
					var cts = _cancellations[download];
					cts.Cancel();
					Thread.Sleep(500);
				}

				if (_dowloads.Contains(download))
					_dowloads.Remove(download);
			}, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
		}

		public async void StartAsync(Download download)
		{
			var cts = new CancellationTokenSource();
			var token = cts.Token;
			_cancellations[download] = cts;
			await DownloadResourceAsync(download, token);
		}

		private async Task DownloadResourceAsync(Download download, CancellationToken token)
		{
			await Task.Factory.StartNew(() =>
			{
				var webClient = new WebClient();
				try
				{
					download.Status = Status.InProgress;
					webClient.DownloadProgressChanged += async (sender, args) =>
					{
						download.PercentsDownloaded = args.ProgressPercentage;
						if (token.IsCancellationRequested)
						{
							webClient.CancelAsync();
							download.Status = Status.Cancelled;
							await Task.Factory.StartNew(() =>
							{
								Thread.Sleep(500);
								if (File.Exists(download.LocalFileName))
									File.Delete(download.LocalFileName);
							});
						}
						else if (args.BytesReceived == args.TotalBytesToReceive)
						{
							download.Status = Status.Completed;
						}
					};
					webClient.DownloadFileAsync(download.Uri, download.LocalFileName);
				}
				finally
				{
					webClient.Dispose();
				}
			}, token, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
		}

		public async void CancelDownloadAsync(Download download)
		{
			await Task.Factory.StartNew(() =>
			{
				var cts = _cancellations[download];
				cts.Cancel();
			}, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void SetCurrentDownload(Download download)
		{
			_selected = download;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CanRunDownload)));
		}

		private Download _selected;

		public bool CanRunDownload => _selected != null;
	}
}
