using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContinuousTasks
{
	class Program
	{
		static void Main(string[] args)
		{
			RunRegardlessTask();
			RunSecondTaskWithoutSuccess();
			ReuseParentThreadIfFailed();
			Console.ReadLine();
		}

		private static void RunRegardlessTask()
		{
			Console.WriteLine("\nRegardlessTask Example");

			var t = Task.Run(() => Console.WriteLine("Success task")).ContinueWith(task => Console.WriteLine("Second task"));
			Task.WaitAll(t);

			Console.WriteLine();

			t = Task.Run(() =>
			{
				Console.WriteLine("Throw exception");
				throw new Exception();
			}).ContinueWith(task => Console.WriteLine("Second task"));
			Task.WaitAll(t);
		}

		private static void RunSecondTaskWithoutSuccess()
		{
			Console.WriteLine("\nSecondTaskWithoutSuccess Example");

			var t = Task.Run(() => Console.WriteLine("Success task\n")).ContinueWith(task => Console.WriteLine("Second task"), TaskContinuationOptions.NotOnRanToCompletion);
			if (t.Status == TaskStatus.RanToCompletion)
				Task.WaitAll(t);

			Console.WriteLine();

			t = Task.Run(() =>
			{
				Console.WriteLine("Throw exception");
				throw new Exception();
			}).ContinueWith(task => Console.WriteLine("Second task"), TaskContinuationOptions.NotOnRanToCompletion);
			if (t.Status == TaskStatus.RanToCompletion)
				Task.WaitAll(t);
		}

		private static void ReuseParentThreadIfFailed()
		{
			Console.WriteLine("\nReuseParentThreadIfFailed Example");

			var t = Task.Run(() => Console.WriteLine("Success task\n")).ContinueWith(task => Console.WriteLine("Second task"), TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
			if (t.Status == TaskStatus.RanToCompletion)
				Task.WaitAll(t);

			Console.WriteLine();
			Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
			Console.WriteLine();

			t = Task.Run(() =>
			{
				Console.WriteLine("Throw exception");
				Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
				throw new Exception();
			}).ContinueWith(task =>
				{
					Console.WriteLine("Second task");
					Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
				}, TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
			if (t.Status == TaskStatus.RanToCompletion)
				Task.WaitAll(t);
		}
	}
}
