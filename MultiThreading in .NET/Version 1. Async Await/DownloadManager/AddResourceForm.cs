using System;
using System.Windows.Forms;

namespace DownloadManager
{
	public partial class AddResourceForm : Form
	{
		public AddResourceForm(Download download)
		{
			InitializeComponent();
			Bind(download);
		}

		private void Bind(Download download)
		{
            var bs = new BindingSource {DataSource = download};

			textEditAddress.DataBindings.Add(nameof(textEditAddress.EditValue), bs, nameof(download.Uri), true, DataSourceUpdateMode.OnPropertyChanged);
		    buttonEditFileName.DataBindings.Add(nameof(buttonEditFileName.EditValue), bs, nameof(download.LocalFileName), true, DataSourceUpdateMode.OnPropertyChanged);
			textEditCaption.DataBindings.Add(nameof(textEditCaption.EditValue), bs, nameof(download.Caption), true, DataSourceUpdateMode.OnPropertyChanged);
		}

		public string Uri => textEditAddress.EditValue?.ToString();
		public string FileName => buttonEditFileName.EditValue?.ToString();
		public string Caption => textEditCaption.EditValue?.ToString();

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

        private void buttonEditFileName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    buttonEditFileName.EditValue = dialog.FileName;
                }
            }
        }
    }
}
