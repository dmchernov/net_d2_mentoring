using System;
using System.Runtime.Caching;

namespace Sum
{
	public class SumCache
	{
		private readonly ObjectCache _cache = MemoryCache.Default;

		public long? Get(int value)
		{
			var result = _cache.Get(value.ToString()) as long?;
			return result;
		}

		public void Set(int number, long sum)
		{
			_cache.Set(number.ToString(), sum, DateTimeOffset.Now.AddSeconds(120));
		}
	}
}
