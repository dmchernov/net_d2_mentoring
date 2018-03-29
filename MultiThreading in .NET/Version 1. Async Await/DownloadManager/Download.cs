using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using DownloadManager.Annotations;

namespace DownloadManager
{
	public class Download : INotifyPropertyChanged
	{
		private Status _status;
		private int _percentsdownloaded;

		[Required]
		public string Caption { get; set; }

		[Required]
		public Uri Uri { get; set; }

		[Required]
		public string LocalFileName { get; set; }

		public Status Status
		{
			get => _status;
			set
			{
				if (value == _status) return;
				_status = value;
				OnPropertyChanged();
			}
		}

		public int PercentsDownloaded
		{
			get => _percentsdownloaded;
			set
			{
				if (value == _percentsdownloaded) return;
				_percentsdownloaded = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
