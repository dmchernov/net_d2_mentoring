using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncRepository
{
	interface IRepository
	{
		Task Create(Customer customer);
		Task Update(Customer customer, int customerId);
		Task Delete(Customer customer);
		Task<Customer> GetCustomerById(int customerId);

		event EventHandler<string> RepositoryMessageGenerated;
		event EventHandler<IList<Customer>> DatasourceChanged;
	}
}
