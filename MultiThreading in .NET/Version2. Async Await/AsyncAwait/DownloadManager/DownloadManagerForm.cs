using System;
using System.Windows.Forms;

namespace DownloadManager
{
	public partial class DownloadManagerForm : Form
	{
		private DownloadModel _model;

		private Download SelectedDownload
		{
			get
			{
				var selectedRows = gridView1.GetSelectedRows();
				if (selectedRows.Length == 1)
				{
					var handle = selectedRows[0];
					return gridView1.GetRow(handle) as Download;
				}

				return null;
			}
		}

		public DownloadManagerForm()
		{
			InitializeComponent();
			_model = new DownloadModel();
			RefreshGrid();
		}

		private void simpleButtonAdd_Click(object sender, EventArgs e)
		{
			var form = new AddResourceForm();
			var result = form.ShowDialog();
			if (result == DialogResult.OK)
			{
				_model.Add(form.Uri, form.Caption, form.FileName);
			}
		}

		private void RefreshGrid()
		{
			gridControlDownloads.DataSource = _model.Downloads;
		}

		private void simpleButtonRun_Click(object sender, EventArgs e)
		{
			_model.Start(SelectedDownload);
		}

		private void simpleButtonCancel_Click(object sender, EventArgs e)
		{
			_model.CancelDownload(SelectedDownload);
		}

		private void simpleButtonDelete_Click(object sender, EventArgs e)
		{
			_model.Delete(SelectedDownload);
		}
	}
}
