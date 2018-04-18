using System;
using System.Runtime.InteropServices;

namespace PowerLibrary
{
	public class PowerInformation
	{
		private const int SYSTEM_POWER_INFORMATION_LEVEL = 12;
		private const int SYSTEM_BATTERY_STATE_LEVEL = 5;
		private const int LAST_SLEEP_TIME_LEVEL = 15;
		private const int LAST_WAKE_TIME_LEVEL = 14;

		const uint STATUS_SUCCESS = 0;

		public struct SystemBatteryState
		{
			public byte AcOnLine;
			public byte BatteryPresent;
			public byte Charging;
			public byte Discharging;
			public byte spare1;
			public byte spare2;
			public byte spare3;
			public byte spare4;
			public UInt32 MaxCapacity;
			public UInt32 RemainingCapacity;
			public Int32 Rate;
			public UInt32 EstimatedTime;
			public UInt32 DefaultAlert1;
			public UInt32 DefaultAlert2;
		}

		public struct SystemPowerInformation
		{
			public uint MaxIdlenessAllowed;
			public uint Idleness;
			public uint TimeRemaining;
			public byte CoolingMode;
		}

		[DllImport("powrprof.dll")]
		private static extern uint CallNtPowerInformation(
			int informationLevel,
			IntPtr lpInputBuffer,
			int nInputBufferSize,
			out SystemBatteryState lpOutputBuffer,
			int nOutputBufferSize
		);

		[DllImport("powrprof.dll")]
		private static extern uint CallNtPowerInformation(
			int informationLevel,
			IntPtr lpInputBuffer,
			int nInputBufferSize,
			out SystemPowerInformation lpOutputBuffer,
			int nOutputBufferSize
		);

		[DllImport("powrprof.dll")]
		private static extern uint CallNtPowerInformation(
			int informationLevel,
			IntPtr lpInputBuffer,
			int nInputBufferSize,
			out long lpOutputBuffer,
			int nOutputBufferSize
		);

		public static SystemBatteryState GetSystemBatteryState()
		{
			SystemBatteryState state;

			uint retval = CallNtPowerInformation(
				SYSTEM_BATTERY_STATE_LEVEL,
				IntPtr.Zero,
				0,
				out state,
				Marshal.SizeOf(typeof(SystemBatteryState))
			);

			if (retval == STATUS_SUCCESS)
			{
				return state;
			}

			throw new InvalidOperationException();
		}

		public static SystemPowerInformation GetSystemPowerInformation()
		{
			SystemPowerInformation info;

			uint retval = CallNtPowerInformation(
				SYSTEM_POWER_INFORMATION_LEVEL,
				IntPtr.Zero,
				0,
				out info,
				Marshal.SizeOf(typeof(SystemPowerInformation))
			);

			if (retval == STATUS_SUCCESS)
			{
				return info;
			}

			throw new InvalidOperationException();
		}

		public static DateTime GetLastSleepTime()
		{
			long intDate;

			uint retval = CallNtPowerInformation(
				LAST_SLEEP_TIME_LEVEL,
				IntPtr.Zero,
				0,
				out intDate,
				Marshal.SizeOf(typeof(long))
			);

			if (retval == STATUS_SUCCESS)
			{
				return new DateTime(intDate);
			}

			throw new InvalidOperationException();
		}

		public static DateTime GetLastWakeTime()
		{
			long intDate;

			uint retval = CallNtPowerInformation(
				LAST_WAKE_TIME_LEVEL,
				IntPtr.Zero,
				0,
				out intDate,
				Marshal.SizeOf(typeof(long))
			);

			if (retval == STATUS_SUCCESS)
			{
				return new DateTime(intDate);
			}

			throw new InvalidOperationException();
		}
	}
}
