using System.Collections.Generic;
using System.Threading.Tasks;
using QuickBooks.Net.Data.Models;
using QuickBooks.Net.Data.Models.Batch;

namespace QuickBooks.Net.Controllers
{
    public interface ICustomerController
    {
        Task<Customer> GetCustomerAsync(int customerId);

        Task<IEnumerable<Customer>> GetCustomersAsync(bool activeAndInactive = false, bool onlyInactive = false,
            int startPosition = 1, int maxResults = 100);

        Task<IEnumerable<Customer>> QueryCustomersAsync(string query);

        Task<int> GetCustomerCountAsync();

        Task<Customer> CreateCustomerAsync(Customer customer);

        Task<IBatchResponse<Customer>> CreateCustomersAsync(IEnumerable<Customer> customers);

        Task<IBatchResponse<Customer>> CreateCustomersAsync(params Customer[] customers);

        Task<Customer> UpdateCustomerAsync(Customer customer);

        Task<IBatchResponse<Customer>> UpdateCustomersAsync(IEnumerable<Customer> customers);

        Task<IBatchResponse<Customer>> UpdateCustomersAsync(params Customer[] customers);

        Task<Customer> DeactiveCustomerAsync(Customer customer);

        Task<Customer> DeactiveCustomerAsync(int customerId, int syncToken);

        Task<IBatchResponse<Customer>> DeactivateCustomersAsync(IEnumerable<Customer> customers);

        Task<IBatchResponse<Customer>> DeactivateCustomersAsync(params Customer[] customers);
    }
}
