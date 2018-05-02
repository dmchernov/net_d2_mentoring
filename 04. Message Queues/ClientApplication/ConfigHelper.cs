using System;
using System.Configuration;
using System.Windows.Forms;
using Entities;
using Microsoft.ServiceBus.Messaging;
using QueueHelper;

namespace ClientApplication
{
	public class ConfigHelper
	{
		private readonly ServiceBusHelper _serviceBusHelper = new ServiceBusHelper();
		private SubscriptionClient _client;
		private readonly string _subscriptionName = Guid.NewGuid().ToString();

		public void StartSettingsWath()
		{
			_serviceBusHelper.CreateSubscription(_subscriptionName);
			_client = _serviceBusHelper.GetSubscriptionClient(_subscriptionName);

			_client.OnMessage(message =>
			{
				var newSettings = message.GetBody<Settings>();
				UpdateConfig(newSettings);
				MessageBox.Show($@"New part size: {newSettings.PartSize}");
				message.Complete();
			});
		}

		private void UpdateConfig(Settings settings)
		{
			try
			{
				var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				var appSettings = configFile.AppSettings.Settings;
				appSettings["partSize"].Value = settings.PartSize.ToString();
				appSettings["maxFileSize"].Value = settings.MaxFileSize.ToString();
				configFile.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
			}
			catch
			{
				//
			}
		}

		public void StopWatch()
		{
			_client.Close();
			_serviceBusHelper.DeleteSubscription(_subscriptionName);
		}
	}
}
