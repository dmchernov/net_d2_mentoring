using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sum
{
	class Program
	{
		private static readonly Calculator Calc = new Calculator();
		private static CancellationTokenSource _tokenSource;
		private static CancellationToken _cancellationToken;
		private static int _value;

		static void Main()
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
				Console.WriteLine($"Введите целое число от нуля до {Int32.MaxValue}, или \"exit\" для завершения работы приложения:");
				var inputString = Console.ReadLine() ?? String.Empty;

				if (inputString.Equals("exit", StringComparison.OrdinalIgnoreCase))
					Environment.Exit(0);

				if (!int.TryParse(inputString, out _value))
					Console.WriteLine("Не удалось прочитать введенные данные.");
			}
			_tokenSource.Cancel();
			ResetCancellationToken();
		}

		private static async void StartCalcAsync(int value)
		{
			Console.WriteLine($"Запуск вычисления суммы чисел от 0 до {value}");
			var token = _cancellationToken;
			var task = new TaskFactory<long>().StartNew(() => Calc.Sum(value, token), token);
			long result;
			try
			{
				result = await task;
			}
			catch (Exception ex)
			{
				if (task.IsCanceled)
					Console.WriteLine($"Вычисление суммы чисел от 0 до {value} было отменено");
				else
					Console.WriteLine(ex.Message);
				return;
			}

			Console.WriteLine($"Результат вычисления суммы чисел от 0 до {value} : {result}");
		}
	}
}
