using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sum
{
	class Program
	{
		private static Calculator _calc = new Calculator();
		private static CancellationTokenSource _tokenSource;
		private static CancellationToken _cancellationToken;
		private static int _value;

		static void Main(string[] args)
		{
			ResetCancellationToken();

			while (true)
			{
				ReadInput();
				StartCalcAsync(_value);
			}
		}

		private static void ResetCancellationToken()
		{
			_tokenSource = new CancellationTokenSource();
			_cancellationToken = _tokenSource.Token;
		}

		private static void ReadInput()
		{
			_value = -1;
			while (_value < 1)
			{
				Console.WriteLine(new string('-', 30));
				Console.WriteLine("Введите число больше нуля, или \"exit\" для завершения работы приложения:");
				var inputString = Console.ReadLine() ?? String.Empty;

				if (inputString.Equals("exit", StringComparison.OrdinalIgnoreCase))
					Environment.Exit(0);

				int.TryParse(inputString, out _value);
			}
			_tokenSource.Cancel();
			ResetCancellationToken();
		}

		private static async void StartCalcAsync(int value)
		{
			Console.WriteLine($"Запуск вычисления суммы чисел от 1 до {value}");
			var token = _cancellationToken;
			var task = new TaskFactory<long>().StartNew(() => _calc.Sum(value, token), token);
			long result;
			try
			{
				result = await task;
			}
			catch
			{
				if (task.IsCanceled)
					Console.WriteLine($"Вычисления суммы чисел от 1 до {value} было отменено");
				return;
			}

			Console.WriteLine($"Результат вычисления суммы чисел от 1 до {value} : {result}");
		}
	}
}
