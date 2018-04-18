using System;
using NUnit.Framework;
using static PowerLibrary.PowerInformation;

namespace Tests
{
	[TestFixture]
	public class PowerInformationTests
	{
		[Test]
		public void SystemBatteryState_Test()
		{
			var result = GetSystemBatteryState();
			PrintAllPowerInfo(result);
		}

		[Test]
		public void SystemPowerInformation_Test()
		{
			var result = GetSystemPowerInformation();
			PrintAllPowerInfo(result);
		}

		[Test]
		public void LastSleepTime_Test()
		{
			var result = GetLastSleepTime();
			Console.WriteLine(result);
		}

		[Test]
		public void LastWakeTime_Test()
		{
			var result = GetLastWakeTime();
			Console.WriteLine(result);
		}

		[Test]
		public void ReserveHiberFile_Test()
		{
			ReserveHiberFile();
		}

		private void PrintAllPowerInfo<T>(T data)
		{
			var fields = typeof(T).GetFields();
			foreach (var info in fields)
			{
				Console.WriteLine($"{info.Name} = {info.GetValue(data)}");
			}
		}
	}
}
