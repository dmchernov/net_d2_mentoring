using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace QueueHelper
{
	public class ServiceBusHelper
	{
		private const string TOPIC_NAME = "SettingsTopic";
		public QueueClient GetFileTransferQueueClientReceiveAndDelete()
		{
			var client = QueueClient.Create("files", ReceiveMode.ReceiveAndDelete);
			return client;
		}

		public QueueClient GetFileTransferQueueClientPeekLock()
		{
			var client = QueueClient.Create("files", ReceiveMode.PeekLock);
			return client;
		}

		public QueueClient GetSettingsQueueClient()
		{
			var client = QueueClient.Create("settings", ReceiveMode.PeekLock);
			return client;
		}

		public void CreateSubscription(string name)
		{
			var manager = NamespaceManager.Create();
			manager.CreateSubscription(TOPIC_NAME, name);
		}

		public void DeleteSubscription(string name)
		{
			var manager = NamespaceManager.Create();
			manager.DeleteSubscription(TOPIC_NAME, name);
		}

		public TopicClient GetSettingsTopicClient()
		{
			var client = TopicClient.Create(TOPIC_NAME);
			return client;
		}

		public SubscriptionClient GetSubscriptionClient(string subscriptionName)
		{
			var client = SubscriptionClient.Create(TOPIC_NAME, subscriptionName, ReceiveMode.ReceiveAndDelete);
			return client;
		}
	}
}
