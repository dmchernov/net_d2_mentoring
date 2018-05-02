using System;
using System.Windows.Forms;

namespace ClientApplication
{
	public partial class ClientForm : Form
	{
		private readonly Presenter _presenter;
		private string SelectedFilePath => buttonEditFile.EditValue?.ToString() ?? String.Empty;

		public ClientForm(Model model)
		{
			InitializeComponent();
			_presenter = new Presenter(this, model);
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(message);
		}

		private void simpleButtonSend_Click(object sender, EventArgs e)
		{
			_presenter.SendFile(SelectedFilePath);
		}

		private void buttonEditFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			using (var dialog = new OpenFileDialog())
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					buttonEditFile.EditValue = dialog.FileName;
				}
			}
		}
	}
}
