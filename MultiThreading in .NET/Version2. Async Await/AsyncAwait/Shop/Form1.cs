using System;
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
			lookUpEditAllProducts.Properties.DataSource = _model.AllProducts;
			gridControl1.DataSource = _model.SelectedProducts;

			_bs.DataSource = _model;
			textEditTotal.DataBindings.Add(nameof(textEditTotal.EditValue), _bs, nameof(_model.Sum), true,
				DataSourceUpdateMode.OnPropertyChanged);
		}

		private void simpleButtonAdd_Click(object sender, EventArgs e)
		{
			_model.Add(SelectedProductToAdd);
		}

		private void simpleButtonRemove_Click(object sender, EventArgs e)
		{
			var p = gridView1.GetFocusedRow() as Product;
			_model.Delete(p);
		}
	}
}
