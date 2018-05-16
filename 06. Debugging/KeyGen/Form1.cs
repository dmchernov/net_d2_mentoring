using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace KeyGen
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			IEnumerable<byte> addressBytes = NetworkInterface.GetAllNetworkInterfaces().First().GetPhysicalAddress().GetAddressBytes();
			var converter = new Converter();
			converter.Bytes = BitConverter.GetBytes(DateTime.Now.Date.ToBinary());
			var args = String.Join("-", addressBytes.Select(converter.Convert).Select(Functions.GetInt));
			textBox1.Text = args;
		}
	}
}
