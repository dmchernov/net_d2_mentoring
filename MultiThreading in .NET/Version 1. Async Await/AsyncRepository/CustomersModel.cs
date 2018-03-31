using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using AsyncRepository.Annotations;

namespace AsyncRepository
{
	public class CustomersModel : INotifyPropertyChanged
	{
		private readonly IRepository _repository;

		public BindingList<Customer> Customers { get; private set; } = new BindingList<Customer>();

		private string[] _stringLog = new[] {""};
		public string[] Log
		{
			get => _stringLog;
			private set => _stringLog = value;
		}
		private IList<string> _log = new List<string>();
		private int _selectedId;

		public int SelectedId
		{
			set => _selectedId = value;
		}

		public CustomersModel(IRepository repository)
		{
			_repository = repository;
			_repository.RepositoryMessageGenerated += _repository_RepositoryMessageGenerated;
			_repository.DatasourceChanged += _repository_DatasourceChanged;
		}

		private void _repository_DatasourceChanged(object sender, IList<Customer> e)
		{
			Customers = new BindingList<Customer>(e);
			OnPropertyChanged(nameof(Customers));
		}

		private void _repository_RepositoryMessageGenerated(object sender, string e)
		{
			_log.Add(e);
			Log = _log.ToArray();
			OnPropertyChanged(nameof(Log));
		}

		public async void AddCustomer(string fName, string lName, int age)
		{
			var customer = new Customer {Age = age, FirstName = fName, LastName = lName};
			await _repository.Create(customer).ConfigureAwait(true);
		}

		public async void UpdateCustomer(string fName, string lName, int age)
		{
			var customer = new Customer {Age = age, FirstName = fName, LastName = lName};
			await _repository.Update(customer, _selectedId);
		}

		public async void DeleteCustomer(int customerId)
		{
			await _repository.Delete(customerId);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
