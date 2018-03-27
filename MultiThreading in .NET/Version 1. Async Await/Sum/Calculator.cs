using System;
using System.Threading;

namespace Sum
{
	public class Calculator
	{
		public long Sum(int value, CancellationToken token)
		{
			if (value < 0)
				throw new ArgumentException("Число должно быть больше нуля");

			long result = 0;
			for (int i = 1; i <= value; i++)
			{
				if (token.IsCancellationRequested)
					token.ThrowIfCancellationRequested();

				result += i;
				Thread.Sleep(10);
			}

			return result;
		}
	}
}
