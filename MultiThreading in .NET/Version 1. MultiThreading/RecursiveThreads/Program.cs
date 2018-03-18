using System;
using System.Threading;

namespace RecursiveThreads
{
	class Program
	{
		private static int _counter = 0;
		static void Main(string[] args)
		{
			Run(100);
			Console.ReadLine();
		}

		private static void Run(object begin)
		{
			if (_counter++ == 10)
				return;

			int number;
			if (!Int32.TryParse(begin.ToString(), out number))
				throw new ArgumentException();

			Console.WriteLine(number--);
			var thread = new Thread(Run);
			thread.Start(number);
			thread.Join();
		}
	}
}
