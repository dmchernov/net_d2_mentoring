using System;
using System.Windows.Forms;

namespace ClientApplication
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var configHelper = new ConfigHelper();
			configHelper.StartSettingsWath();

			try
			{
				Application.Run(new ClientForm(new Model()));
			}
			finally
			{
				configHelper.StopWatch();
			}
		}
	}
}
