using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;

namespace SharedCollection
{
	internal class Program
	{
		private static readonly object _lockObj = new object();

		private static readonly IList<int> _collection = new List<int>();

		static Program()
		{
		}

		private static void Main(string[] args)
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
				Task.Run(() => PrintCollection());
				Thread.Sleep(50);
			}
		}

		private static void PrintCollection()
		{
			string toPrint;
			lock (_lockObj)
			{
				toPrint = string.Join(";", _collection);
				Console.WriteLine(toPrint);
			}
		}

		private static void AddElementToCollection(int i)
		{
			lock (_lockObj)
			{
				Console.WriteLine($"{i} has been added to collection");
				_collection.Add(i);
			}
		}
	}
}
