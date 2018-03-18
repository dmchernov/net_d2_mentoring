using System;
using System.Windows.Forms;

namespace DownloadManager
{
	public partial class AddResourceForm : Form
	{
		public string Uri => textEditAddress.EditValue?.ToString();
		public string FileName => textEditFileName.EditValue?.ToString();
		public string Caption => textEditCaption.EditValue?.ToString();

		public AddResourceForm()
		{
			InitializeComponent();
		}

		private void simpleButtonAdd_Click(object sender, EventArgs e)
		{
			if (!String.IsNullOrWhiteSpace(Uri)
				&& !String.IsNullOrWhiteSpace(FileName)
				&& !String.IsNullOrWhiteSpace(Caption))
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}
