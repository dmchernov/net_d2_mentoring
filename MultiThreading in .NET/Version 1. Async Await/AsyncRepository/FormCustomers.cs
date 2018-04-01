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
					UpdateLog();
					break;
				case nameof(_model.Customers):
					UpdateCustomers();
					break;
			}
		}

		private void UpdateLog()
		{
			var log = _model.Log.ToList().AsReadOnly().ToArray();
			if (InvokeRequired)
				Invoke(new MethodInvoker(() => UpdateLogAndScroll(log)));
			else
				UpdateLogAndScroll(log);
		}

		private void UpdateLogAndScroll(string[] log)
		{
			memoEditLog.Lines = log;
			memoEditLog.SelectionStart = Int32.MaxValue;
			memoEditLog.ScrollToCaret();
		}

		private void UpdateCustomers()
		{
			var customers = _model.Customers.ToList().AsReadOnly();
			if (InvokeRequired)
				Invoke(new MethodInvoker(() => gridControlCustomers.DataSource = customers));
			else
				gridControlCustomers.DataSource = customers;
		}

		private int SelectedId
		{
			get
			{
				var c = gridView1.GetFocusedRow() as Customer;
				return c != null ? c.Id.GetValueOrDefault() : 0;
			}
		}

		private string FirstName => textEditFirstName.EditValue?.ToString();
		private string LastName => textEditLastName.EditValue?.ToString();
		private int Age => Int32.Parse(spinEditAge.EditValue.ToString());

		private void simpleButtonAdd_Click(object sender, EventArgs e)
		{
			_model.AddCustomer(FirstName, LastName, Age);
		}

		private void simpleButtonUpdate_Click(object sender, EventArgs e)
		{
			_model.SelectedId = SelectedId;
			_model.UpdateCustomer(FirstName, LastName, Age);
		}

		private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			textEditId.EditValue = SelectedId;
		}

		private void simpleButtonDelete_Click(object sender, EventArgs e)
		{
			_model.DeleteCustomer(SelectedId);
		}

		private async void simpleButtonGet_Click(object sender, EventArgs e)
		{
			var customerAsString = await _model.GetCustomerAsString(SelectedId);
			if (!String.IsNullOrEmpty(customerAsString))
				MessageBox.Show(customerAsString);
		}
	}
}
