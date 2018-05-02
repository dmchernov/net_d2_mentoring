using Entities;
using Microsoft.ServiceBus.Messaging;
using QueueHelper;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace ServiceManager
{
	public class ConfigWatcher
	{
		private readonly FileSystemWatcher _watcher;
		private readonly TopicClient _queueClient;
		private readonly ServiceBusHelper _helper = new ServiceBusHelper();
		private readonly string _settingsPath = Path.Combine(Directory.GetCurrentDirectory(), "Settings.xml");

		public ConfigWatcher()
		{
			_watcher = new FileSystemWatcher(Directory.GetCurrentDirectory(), "Settings.xml");

			_queueClient = _helper.GetSettingsTopicClient();
			SendSettings();
		}

		public void Start(CancellationToken cancellationToken)
		{
			cancellationToken.Register(StopWatching);
			_watcher.NotifyFilter = NotifyFilters.LastWrite;
			_watcher.Changed += _watcher_Changed;
			_watcher.EnableRaisingEvents = true;
		}

		private void _watcher_Changed(object sender, FileSystemEventArgs e)
		{
			SendSettings();
		}

		private void SendSettings()
		{
			var serializer = new XmlSerializer(typeof(Settings));
			using (var reader = new FileStream(_settingsPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				try
				{
					var settings = (Settings)serializer.Deserialize(reader);
					_queueClient.Send(new BrokeredMessage(settings));
				}
				catch
				{
					//
				}
			}
		}

		private void StopWatching()
		{
			_watcher.Changed -= _watcher_Changed;
		}
	}
}
