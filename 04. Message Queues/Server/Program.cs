using ServiceManager;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
	class Program
	{
		static void Main()
		{
			var receiver = new Receiver(new FileManager());
			var configWatcher = new ConfigWatcher();
			var cts = new CancellationTokenSource();
			var token = cts.Token;
			var task = receiver.Run(token);
			configWatcher.Start(token);
			Console.WriteLine("Service started");
			Console.WriteLine("Press any key to stop service");
			Console.ReadKey();
			cts.Cancel();
			Task.WaitAll(task);
			Console.WriteLine("Service stopped");
			Thread.Sleep(1000);
		}
	}
}
