using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncRepository
{
	class SlowRepository : IRepository
	{
		private readonly IList<int> _processedObjects = new List<int>();
		private static readonly object Lock = new object();
		private static readonly ObservableCollection<Customer> Customers = new ObservableCollection<Customer>();
		private static int _counter = 1;

		public SlowRepository()
		{
			Customers.CollectionChanged += _customers_CollectionChanged;
		}

		public event EventHandler<string> RepositoryMessageGenerated;
		public event EventHandler<IList<Customer>> DatasourceChanged;

		public async Task Create(Customer customer)
		{
			await Task.Factory.StartNew(() =>
			{
				GenerateMessage("Connecting to server . . .");
				Thread.Sleep(2000);
				GenerateMessage("Saving customer . . .");
				Thread.Sleep(2000);
				customer.Id = _counter++;
				AddCustomer(customer);
				GenerateMessage($"Customer has been saved. ID = {customer.Id}");
			});
		}

		public async Task Delete(int customerId)
		{
			await Task.Factory.StartNew(() =>
			{
				BeginProcessing(customerId);
				GenerateMessage("Connecting to server . . .");
				Thread.Sleep(2000);
				GenerateMessage("Deleting customer . . .");
				Thread.Sleep(2000);
				var customer = Customers.FirstOrDefault(c => c.Id == customerId);
				if (customer == null)
					GenerateMessage($"Customer ID = {customerId} not found");
				else
				{
					RemoveCustomer(customer);
					GenerateMessage($"Customer has been saved. ID = {customerId}");
				}
			});
		}

		public async Task<Customer> GetCustomerById(int customerId)
		{
			var customer = await Task.Factory.StartNew(() =>
			{
				GenerateMessage("Connecting to server . . .");
				Thread.Sleep(3000);
				GenerateMessage("Searching customer . . .");
				Thread.Sleep(1000);
				GenerateMessage("Customer has been found.");
				return Customers.FirstOrDefault(c => c.Id == customerId);
			});

			return customer;
		}

		public async Task Update(Customer customer, int customerId)
		{
			await Task.Factory.StartNew(() =>
			{
				BeginProcessing(customerId);
				GenerateMessage("Connecting to server . . .");
				Thread.Sleep(500);
				GenerateMessage("Updating customer . . .");
				Thread.Sleep(4000);
				var customerToUpdate = Customers.FirstOrDefault(c => c.Id == customerId);
				if (customerToUpdate == null)
					GenerateMessage($"Customer ID = {customerId} not found");
				else
				{
					customerToUpdate.FirstName = customer.FirstName;
					customerToUpdate.LastName = customer.LastName;
					customerToUpdate.Age = customer.Age;

					DatasourceChanged?.Invoke(this, Customers);

					GenerateMessage($"Customer ID = {customerId} has been updated");
				}
				EndProcessing(customerId);
			});
		}

		private void _customers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			DatasourceChanged?.Invoke(this, Customers);
		}

		private void GenerateMessage(string message)
		{
			RepositoryMessageGenerated?.Invoke(this, message);
		}

		private void BeginProcessing(int customerId)
		{
			lock (Lock)
			{
				if (_processedObjects.Contains(customerId))
					throw new InvalidOperationException("Object is already in process");

				_processedObjects.Add(customerId);
			}
		}

		private void EndProcessing(int customerId)
		{
			lock (Lock)
			{
				if (_processedObjects.Contains(customerId))
					_processedObjects.Remove(customerId);
			}
		}

		private void RemoveCustomer(Customer customer)
		{
			lock (Lock)
			{
				if (Customers.Contains(customer))
					Customers.Remove(customer);
			}
		}

		private void AddCustomer(Customer customer)
		{
			lock (Lock)
			{
				if (!Customers.Contains(customer))
					Customers.Add(customer);
			}
		}
	}
}
