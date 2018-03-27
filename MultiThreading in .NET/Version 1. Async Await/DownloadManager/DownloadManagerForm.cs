using System;
using System.Windows.Forms;

namespace DownloadManager
{
	public partial class DownloadManagerForm : Form
	{
		private DownloadModel _model;
		private BindingSource _downloadsBindingSource;

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

			_downloadsBindingSource = new BindingSource { DataSource = _model.Downloads };

			_model.PropertyChanged += _model_PropertyChanged;

			simpleButtonRun.DataBindings.Add("Enabled", _model, nameof(DownloadModel.CanRunDownload), false, DataSourceUpdateMode.OnPropertyChanged);
			simpleButtonCancel.DataBindings.Add("Enabled", _model, nameof(DownloadModel.CanCancelDownload), false, DataSourceUpdateMode.OnPropertyChanged);
			simpleButtonDelete.DataBindings.Add("Enabled", _model, nameof(DownloadModel.CanDeleteDownload), false, DataSourceUpdateMode.OnPropertyChanged);
			gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;
			RefreshGrid();
		}

		private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			_model.SetCurrentDownload(gridView1.GetFocusedRow() as Download);
		}

		private void _model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			gridControlDownloads.RefreshDataSource();
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
			_model.StartAsync(SelectedDownload);
		}

		private void simpleButtonCancel_Click(object sender, EventArgs e)
		{
			_model.CancelDownloadAsync(SelectedDownload);
		}

		private void simpleButtonDelete_Click(object sender, EventArgs e)
		{
			_model.DeleteAsync(SelectedDownload);
		}
	}
}
