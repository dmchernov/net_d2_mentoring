using System;
using System.Diagnostics;
using System.Threading;

namespace Sum
{
	public class Calculator
	{
		//private object _lock = new object();
		private SumCache _cache = new SumCache();
		public long Sum(int value, CancellationToken token)
		{
			if (value < 0)
				throw new ArgumentException("Число должно быть больше нуля");

			long result = 0;
			//long maxValue = value + 1;

			var sw = new Stopwatch();
			sw.Start();
			for (int i = value; i > 0; i--)
			//Parallel.For(0, maxValue, i =>
			{
				if (token.IsCancellationRequested)
					token.ThrowIfCancellationRequested();

				var fromCache = _cache.Get(i);
				if (fromCache.HasValue)
				{
					result += fromCache.Value;
					break;
				}

				result += i;

			}//);
			sw.Stop();
			var time = sw.Elapsed;
			Console.WriteLine($"From 0 to {value}: {time:g}");

			_cache.Set(value, result);
			return result;
		}
	}
}
