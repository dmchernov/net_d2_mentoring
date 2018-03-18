using System;
using System.Threading;

namespace RecursiveThreadPool
{
	class Program
	{
		private static int _counter = 0;
		private static Semaphore _sem = new Semaphore(3, 3);

		static void Main(string[] args)
		{
			ThreadPool.QueueUserWorkItem(Run, 100);
			Console.ReadLine();
		}

		private static void Run(object begin)
		{
			if (_counter++ == 10)
				return;

			int number;
			if (!Int32.TryParse(begin.ToString(), out number))
				throw new ArgumentException();

			_sem.WaitOne();

			Console.WriteLine(number--);
			ThreadPool.QueueUserWorkItem(Run, number);

			_sem.Release();
		}
	}
}
