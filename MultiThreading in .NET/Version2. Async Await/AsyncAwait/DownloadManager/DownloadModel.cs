using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadManager
{
	public class DownloadModel
	{
		private IList<Download> _dowloads = new ObservableCollection<Download>();
		private readonly IDictionary<Download, CancellationTokenSource> _cancellations = new ConcurrentDictionary<Download, CancellationTokenSource>();

		public IList<Download> Downloads => _dowloads;

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
		}

		public void Delete(Download download)
		{
			if (_cancellations.Keys.Contains(download))
			{
				var cts = _cancellations[download];
				cts.Cancel();
				Thread.Sleep(500);
			}

			if (_dowloads.Contains(download))
				_dowloads.Remove(download);
		}

		public void Start(Download download)
		{
			var cts = new CancellationTokenSource();
			var token = cts.Token;
			_cancellations[download] = cts;
			DownloadResource(download, token);
		}

		private async void DownloadResource(Download download, CancellationToken token)
		{
			await Task.Run(() =>
			{
				var webClient = new WebClient();
				try
				{
					download.Status = Status.InProgress;
					webClient.DownloadFileAsync(download.Uri, download.LocalFileName);
					webClient.DownloadProgressChanged += (sender, args) =>
					{
						download.Percentsdownloaded = args.ProgressPercentage;
						if (token.IsCancellationRequested)
						{
							webClient.CancelAsync();
							download.Status = Status.Cancelled;
							Thread.Sleep(500);
							if (File.Exists(download.LocalFileName))
								File.Delete(download.LocalFileName);
						}
						else if (args.BytesReceived == args.TotalBytesToReceive)
						{
							download.Status = Status.Completed;
							//webClient.Dispose();
						}
					};
				}
				finally
				{
					webClient.Dispose();
				}
			}, token);
		}

		public void CancelDownload(Download download)
		{
			var cts = _cancellations[download];
			cts.Cancel();
		}
	}
}
