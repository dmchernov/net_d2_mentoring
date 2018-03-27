using System;
using System.Linq;
using System.Windows.Forms;

namespace Shop
{
	public partial class Form1 : Form
	{
		private ShopModel _model;
		private BindingSource _bs = new BindingSource();


		private int SelectedProductToAdd => (int)lookUpEditAllProducts.EditValue;

		public Form1()
		{
			InitializeComponent();

			_model = new ShopModel();
			_model.SelectedChanged += _model_PropertyChanged;
			lookUpEditAllProducts.Properties.DataSource = _model.AllProducts;

			_bs.DataSource = _model;
			textEditTotal.DataBindings.Add(nameof(textEditTotal.EditValue), _model, nameof(_model.Sum), true,
				DataSourceUpdateMode.OnPropertyChanged);
		}

		private void _model_PropertyChanged(object sender, EventArgs e)
		{
			if (dataGridView1.InvokeRequired)
				dataGridView1.Invoke(new MethodInvoker(() => SetDataSource()));
			else
				SetDataSource();
		}

		private void SetDataSource()
		{
			var newDS = _model.SelectedProducts.ToList().AsReadOnly();
			dataGridView1.DataSource = newDS;
			gridControl1.DataSource = newDS;
		}

		private async void simpleButtonAdd_ClickAsync(object sender, EventArgs e)
		{
			await _model.Add(SelectedProductToAdd).ConfigureAwait(true);
		}

		private async void simpleButtonRemove_Click(object sender, EventArgs e)
		{
			var p = gridView1.GetFocusedRow() as Product;
			await _model.Delete(p);
		}
	}
}
