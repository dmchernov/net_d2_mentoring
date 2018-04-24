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
			ShowSystemBatteryState();
		}

		[Test]
		public void SystemPowerInformation_Test()
		{
			ShowSystemPowerInformation();
		}

		[Test]
		public void LastSleepTime_Test()
		{
			ShowLastSleepTime();
		}

		[Test]
		public void LastWakeTime_Test()
		{
			ShowLastWakeTime();
		}

		[Test]
		public void ReserveHiberFile_Test()
		{
			ReserveHiberFile();
		}

		[Test]
		public void RemoveHiberFile_Test()
		{
			RemoveHiberFile();
		}

		[Test]
		public void Hibernate_Test()
		{
			Hibernate();
		}

		[Test]
		public void Suspend_Test()
		{
			Suspend();
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
