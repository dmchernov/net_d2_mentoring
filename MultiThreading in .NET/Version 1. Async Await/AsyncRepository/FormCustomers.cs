using System;
using System.Linq;
using System.Windows.Forms;

namespace AsyncRepository
{
	public partial class FormCustomers : Form
	{
		private readonly CustomersModel _model;

		public FormCustomers(CustomersModel model)
		{
			InitializeComponent();

			_model = model;
			_model.PropertyChanged += _model_PropertyChanged;
		}

		private void _model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(_model.Log):
					var log = _model.Log.ToList().AsReadOnly().ToArray();
					//memoEditLog.Lines = log;
					break;
				case nameof(_model.Customers):
					var customers = _model.Customers.ToList().AsReadOnly();
					dataGridView1.DataSource = customers;
					break;
			}
		}

		private int SelectedId
		{
			get
			{
				var c = dataGridView1.SelectedRows[0].DataBoundItem as Customer;
				return c != null ? c.Id.GetValueOrDefault() : 0;
			}
		}

		private string FirstName => textEditFirstName.EditValue?.ToString();
		private string LastName => textEditLastName.EditValue?.ToString();
		private int Age => Int32.Parse(spinEditAge.EditValue.ToString());

		private void simpleButtonAdd_Click(object sender, System.EventArgs e)
		{
			_model.AddCustomer(FirstName, LastName, Age);
		}
	}
}
