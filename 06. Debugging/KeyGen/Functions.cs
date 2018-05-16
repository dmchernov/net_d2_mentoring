using System;

namespace KeyGen
{
	public class Functions
	{
		public static readonly Functions Instance;
		public static Func<int, int> IntToInt => GetInt;

		static Functions()
		{
			Instance = new Functions();
		}

		public static int GetInt(int a)
		{
			if (a <= 999)
			{
				return a * 10;
			}
			return a;
		}
	}
}