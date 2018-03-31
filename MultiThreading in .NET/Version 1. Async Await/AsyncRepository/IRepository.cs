using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncRepository
{
	public interface IRepository
	{
		Task Create(Customer customer);
		Task Update(Customer customer, int customerId);
		Task Delete(int customerId);
		Task<Customer> GetCustomerById(int customerId);

		event EventHandler<string> RepositoryMessageGenerated;
		event EventHandler<IList<Customer>> DatasourceChanged;
	}
}
