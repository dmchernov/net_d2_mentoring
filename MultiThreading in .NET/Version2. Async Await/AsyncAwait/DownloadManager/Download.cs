using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DownloadManager.Annotations;

namespace DownloadManager
{
	public class Download : INotifyPropertyChanged
	{
		private Status _status;
		private int _percentsdownloaded;
		public string Caption { get; set; }
		public Uri Uri { get; set; }
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

		public int Percentsdownloaded
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
