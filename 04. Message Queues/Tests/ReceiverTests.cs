using NUnit.Framework;
using ServiceManager;
using System.Threading;

namespace Tests
{
	public class ReceiverTests
	{
		[Test]
		public void Receive()
		{
			var receiver = new Receiver(new FileManager(TestContext.CurrentContext.TestDirectory));
			var cts = new CancellationTokenSource();
			var token = cts.Token;
			var t = receiver.Run(token);
			Thread.Sleep(30000);
			cts.Cancel();
		}
	}
}
