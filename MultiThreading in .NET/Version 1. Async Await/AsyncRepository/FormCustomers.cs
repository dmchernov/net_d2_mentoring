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

		    if (InvokeRequired)
		        Invoke(new MethodInvoker(UpdateCustomerGrid));
		    else
		        UpdateCustomerGrid();
		}

	    private void UpdateCustomerGrid()
	    {
	        var currentRowHandle = gridView1.FocusedRowHandle;

	        var customers = _model.Customers.ToList().AsReadOnly();
			gridControlCustomers.DataSource = customers;

	        if (currentRowHandle >= gridView1.RowCount)
	            gridView1.MoveLast();
	        else
	            gridView1.FocusedRowHandle = currentRowHandle;
        }

        private Customer SelectedCustomer => gridView1.GetFocusedRow() as Customer;

	    private string FirstName => textEditFirstName.EditValue?.ToString();
		private string LastName => textEditLastName.EditValue?.ToString();
		private int Age => Int32.Parse(spinEditAge.EditValue.ToString());

		private void simpleButtonAdd_Click(object sender, EventArgs e)
		{
			_model.AddCustomer(FirstName, LastName, Age);
		}

		private void simpleButtonUpdate_Click(object sender, EventArgs e)
		{
			_model.SelectedId = SelectedCustomer.Id ?? 0;
			_model.UpdateCustomer(FirstName, LastName, Age);
		}

		private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			textEditId.EditValue = SelectedCustomer?.Id;
			textEditFirstName.EditValue = SelectedCustomer?.FirstName;
			textEditLastName.EditValue = SelectedCustomer?.LastName;
			spinEditAge.EditValue = SelectedCustomer?.Age;
		}

		private void simpleButtonDelete_Click(object sender, EventArgs e)
		{
			_model.DeleteCustomer(SelectedCustomer.Id ?? 0);
		}

		private async void simpleButtonGet_Click(object sender, EventArgs e)
		{
			var customerAsString = await _model.GetCustomerAsString(SelectedCustomer.Id ?? 0);
			if (!String.IsNullOrEmpty(customerAsString))
				MessageBox.Show(customerAsString);
		}
	}
}
