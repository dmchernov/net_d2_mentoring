using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfTasks
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Starting...");
			var t = Run();
			Task.WaitAll(t);
			Console.WriteLine("Completed");
			Console.ReadLine();
		}

		private static async Task Run()
		{
			var factory = new TaskFactory();

			await factory.StartNew(Get10RandomDigits)
				.ContinueWith(t => MultipleArray(t.Result))
				.ContinueWith(t => SortArray(t.Result))
				.ContinueWith(t => GetAvgValue(t.Result))
				.ContinueWith(t => Console.WriteLine($"AVG: {t.Result}"));

		}

		private static int[] Get10RandomDigits()
		{
			var array = new int[10];
			var r = new Random();
			for (var i = 0; i < 10; i++)
			{
				array[i] = r.Next(1, 20);
			}
			PrintArrayToConsol("Random numbers", array);
			return array;
		}

		private static int[] MultipleArray(int[] numbers)
		{
			var array = new int[numbers.Length];
			var r = new Random().Next(1, 10);
			for (var i = 0; i < array.Length; i++)
			{
				array[i] = numbers[i] * r;
			}
			PrintArrayToConsol("After multipling", array);
			return array;
		}

		private static int[] SortArray(int[] numbers)
		{
			var list = new List<int>(numbers);
			list.Sort();
			var sortedArray = list.ToArray();
			PrintArrayToConsol("Sorted", sortedArray);
			return sortedArray;
		}

		private static double GetAvgValue(int[] numbers)
		{
			var avg = numbers.Average();
			return avg;
		}

		private static void PrintArrayToConsol(string caption, int[] numbers)
		{
			var str = String.Join(";", numbers);
			Console.WriteLine($"{caption} : {str}");
		}
	}
}
