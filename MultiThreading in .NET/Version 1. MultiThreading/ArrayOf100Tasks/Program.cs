using System;
using System.Threading.Tasks;

namespace ArrayOf100Tasks
{
	internal class Program
	{
		private static void Main()
		{
			Console.WriteLine("Start tasks...");

			var tasks = GetTaskArray();
			foreach (var task in tasks) task.Start();
			Task.WaitAll(tasks);

			Console.WriteLine("All tasks has finished");
			Console.ReadLine();
		}

		private static Task[] GetTaskArray()
		{
			var tasks = new Task[100];

			for (var i = 0; i < tasks.Length; i++)
			{
				tasks[i] = GetIterateTask(i);
			}

			return tasks;
		}

		private static Task GetIterateTask(int taskNumber)
		{
			return new Task(() => Iterate(taskNumber));
		}

		private static void Iterate(int taskNumber)
		{
			for (var i = 1; i <= 1000; i++) Console.WriteLine($"Task#{taskNumber} : {i}");
		}
	}
}