using System;
using Microsoft.ServiceBus.Messaging;
using NUnit.Framework;

namespace Tests
{
	public class QueueHelperTests
	{
		[Test]
		public void SendReceiveTest()
		{
			var client = QueueClient.Create("files", ReceiveMode.ReceiveAndDelete);
			client.Send(new BrokeredMessage("Files"));

			var message = client.Receive();
			var s = message.GetBody<string>();
			Console.WriteLine(s);
		}

		[Test]
		public void SendReceiveTest_Settings()
		{
			var client = QueueClient.Create("settings", ReceiveMode.ReceiveAndDelete);
			client.Send(new BrokeredMessage("Settings"));

			var message = client.Receive();
			var s = message.GetBody<string>();
			Console.WriteLine(s);
		}
	}
}
