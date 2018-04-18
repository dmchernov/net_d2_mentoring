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
		private const int SYSTEM_RESERVE_HIBER_FILE_LEVEL = 10;

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
			[Out] IntPtr lpOutputBuffer,
			int nOutputBufferSize
		);

		public static SystemBatteryState GetSystemBatteryState()
		{
			SystemBatteryState state;
			var ptr = IntPtr.Zero;
			try
			{
				ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(SystemBatteryState)));
				uint retval = CallNtPowerInformation(
					SYSTEM_BATTERY_STATE_LEVEL,
					IntPtr.Zero,
					0,
					ptr,
					Marshal.SizeOf(typeof(SystemBatteryState))
				);

				if (retval == STATUS_SUCCESS)
				{
					state = Marshal.PtrToStructure<SystemBatteryState>(ptr);
					return state;
				}
			}
			finally
			{
				if (ptr != IntPtr.Zero)
					Marshal.FreeCoTaskMem(ptr);
			}

			throw new InvalidOperationException();
		}

		public static SystemPowerInformation GetSystemPowerInformation()
		{
			SystemPowerInformation state;
			var ptr = IntPtr.Zero;
			try
			{
				ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(SystemPowerInformation)));
				uint retval = CallNtPowerInformation(
					SYSTEM_POWER_INFORMATION_LEVEL,
					IntPtr.Zero,
					0,
					ptr,
					Marshal.SizeOf(typeof(SystemPowerInformation))
				);

				if (retval == STATUS_SUCCESS)
				{
					state = Marshal.PtrToStructure<SystemPowerInformation>(ptr);
					return state;
				}
			}
			finally
			{
				if (ptr != IntPtr.Zero)
					Marshal.FreeCoTaskMem(ptr);
			}

			throw new InvalidOperationException();
		}

		public static DateTime GetLastSleepTime()
		{
			long ticks;
			var ptr = IntPtr.Zero;
			try
			{
				ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(long)));
				uint retval = CallNtPowerInformation(
					LAST_SLEEP_TIME_LEVEL,
					IntPtr.Zero,
					0,
					ptr,
					Marshal.SizeOf(typeof(long))
				);

				if (retval == STATUS_SUCCESS)
				{
					ticks = Marshal.ReadInt64(ptr);
					return new DateTime(ticks);
				}
			}
			finally
			{
				if (ptr != IntPtr.Zero)
					Marshal.FreeCoTaskMem(ptr);
			}

			throw new InvalidOperationException();
		}

		public static DateTime GetLastWakeTime()
		{
			long ticks;
			var ptr = IntPtr.Zero;
			try
			{
				ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(long)));
				uint retval = CallNtPowerInformation(
					LAST_WAKE_TIME_LEVEL,
					IntPtr.Zero,
					0,
					ptr,
					Marshal.SizeOf(typeof(long))
				);

				if (retval == STATUS_SUCCESS)
				{
					ticks = Marshal.ReadInt64(ptr);
					return new DateTime(ticks);
				}
			}
			finally
			{
				if (ptr != IntPtr.Zero)
					Marshal.FreeCoTaskMem(ptr);
			}

			throw new InvalidOperationException();
		}

		public static void ReserveHiberFile()
		{
			var ptr = IntPtr.Zero;
			try
			{
				var boolPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(bool)));
				Marshal.WriteInt32(boolPtr, 0, 1);
				uint retval = CallNtPowerInformation(
					SYSTEM_RESERVE_HIBER_FILE_LEVEL,
					boolPtr,
					0,
					ptr,
					0
				);

				if (retval != STATUS_SUCCESS)
				{
					throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
			}
			finally
			{
				if (ptr != IntPtr.Zero)
					Marshal.FreeCoTaskMem(ptr);
			}
		}
	}
}
