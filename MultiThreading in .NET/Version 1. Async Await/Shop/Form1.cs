using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Shop
{
	public partial class Form1 : Form
	{
		private ShopModel _model;
		private BindingSource _bs = new BindingSource();


		private int? SelectedProductToAdd => (int?)lookUpEditAllProducts.EditValue;

		public Form1()
		{
			InitializeComponent();

			_model = new ShopModel();
			_model.PropertyChanged += _model_PropertyChanged;
			lookUpEditAllProducts.Properties.DataSource = _model.AllProducts;
		    lookUpEditAllProducts.EditValue = _model.AllProducts[0].Id;

            _bs.DataSource = _model;
		}

		private void _model_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (InvokeRequired)
				Invoke(new MethodInvoker(() => BindModel(e.PropertyName)));
			else
				BindModel(e.PropertyName);
		}

		private void BindModel(string changedProperty)
		{
		    switch (changedProperty)
		    {
                case nameof(_model.SelectedProducts):
                    var currentRowHandle = gridView1.FocusedRowHandle;
                    var newDs = _model.SelectedProducts.GroupBy(p => new { p.Name, p.Id }).Select(pr =>
                        new
                        {
                            pr.Key.Id,
                            pr.Key.Name,
                            Price = pr.Average(prod => prod.Price),
                            Count = pr.Count(),
                            Sum = pr.Sum(prod => prod.Price)
                        });
                    gridControl1.DataSource = newDs;
                    if (currentRowHandle >= gridView1.RowCount)
                        gridView1.MoveLast();
                    else
                        gridView1.FocusedRowHandle = currentRowHandle;
                    break;
                case nameof(_model.Sum):
                    textEditTotal.Text = _model.Sum.ToString();
                    break;
                case nameof(_model.CanRemove):
                    simpleButtonRemove.Enabled = _model.CanRemove;
                    break;
		    }
		}

		private async void simpleButtonAdd_ClickAsync(object sender, EventArgs e)
		{
			await _model.Add(SelectedProductToAdd.GetValueOrDefault()).ConfigureAwait(true);
		}

		private async void simpleButtonRemove_Click(object sender, EventArgs e)
		{
			var p = gridView1.GetFocusedRow() as dynamic;
			await _model.Delete(p.Id);
		}
	}
}
