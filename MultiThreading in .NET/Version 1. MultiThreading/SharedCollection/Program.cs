using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedCollection
{
	internal class Program
	{
		private static readonly object LockObj = new object();

		private static IList<int> Collection { get; set; } = new List<int>();

		private static void Main()
		{
			Run();
			Console.ReadLine();
		}

		private static void Run()
		{
			for (var i = 0; i < 10; i++)
			{
				var p = i;
				Task.Run(() => AddElementToCollection(p));
			}
		}

		private static void PrintCollection()
		{
			string toPrint;
			lock (LockObj)
			{
				toPrint = string.Join(";", Collection);
			}
		    Console.WriteLine(toPrint);
        }

        private static void AddElementToCollection(int element)
		{
			lock (LockObj)
			{
				Console.WriteLine($"{element} has been added to collection");
				Collection.Add(element);
			}

			Task.Run((Action) PrintCollection);
		}
    }
}
