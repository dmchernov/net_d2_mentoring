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
			_model.PropertyChanged += _model_PropertyChanged;
			lookUpEditAllProducts.Properties.DataSource = _model.AllProducts;

			_bs.DataSource = _model;
		}

		private void _model_PropertyChanged(object sender, EventArgs e)
		{
			if (InvokeRequired)
				Invoke(new MethodInvoker(() => SetDataSource()));
			else
				SetDataSource();
		}

		private void SetDataSource()
		{
			var newDS = _model.SelectedProducts.ToList().AsReadOnly();
			gridControl1.DataSource = newDS;

			textEditTotal.Text = _model.Sum.ToString();
			simpleButtonAdd.Enabled = _model.CanAdd;
			simpleButtonRemove.Enabled = _model.CanRemove;
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
