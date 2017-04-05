using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuickBooks.Net.Data.Models;
using QuickBooks.Net.Data.Models.Batch;

namespace QuickBooks.Net.Controllers
{
    public class CustomerController : BaseController, ICustomerController
    {
        protected override string ObjectName => "Customer";

        public CustomerController(QuickBooksClient client, string oAuthVersion) : base(client, oAuthVersion)
        {
        }

        public async Task<Customer> GetCustomerAsync(int customerId)
        {
            return await GetRequest<Customer>(customerId);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync(bool activeAndInactive = false, bool onlyInactive = false, int startPosition = 1, int maxResults = 100)
        {
            // TODO: page = 0  startPosition = page * maxResults + 1
            if(activeAndInactive && onlyInactive)
                throw new ArgumentException($"{nameof(activeAndInactive)} and {nameof(onlyInactive)} cannot be both set to true");

            var query = $"Select * From {ObjectName}";

            if (activeAndInactive)
            {
                query += " Where Active IN (True, False)";
            }
            else if (onlyInactive)
            {
                query += " Where Active = False";
            }

            return await QueryRequest<Customer>(query, startPosition, maxResults);
        }

        public async Task<IEnumerable<Customer>> QueryCustomersAsync(string query)
        {
            return await QueryRequest<Customer>(query, overrideOptions: true);
        }

        public async Task<int> GetCustomerCountAsync()
        {
            return await GetObjectCount<Customer>();
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            return await PostRequest(customer.CreateReturnObject() as Customer);
        }

        public async Task<IBatchResponse<Customer>> CreateCustomersAsync(IEnumerable<Customer> customers)
        {
            return await BatchRequest<Customer>(customers, BatchOperation.Create);
        }

        public async Task<IBatchResponse<Customer>> CreateCustomersAsync(params Customer[] customers)
        {
            return await CreateCustomersAsync(customers.AsEnumerable());
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            return await PostRequest(customer.UpdateReturnObject() as Customer, true);
        }

        public async Task<IBatchResponse<Customer>> UpdateCustomersAsync(IEnumerable<Customer> customers)
        {
            return await BatchRequest<Customer>(customers, BatchOperation.Update);
        }

        public async Task<IBatchResponse<Customer>> UpdateCustomersAsync(params Customer[] customers)
        {
            return await UpdateCustomersAsync(customers.AsEnumerable());
        }

        public async Task<Customer> DeactiveCustomerAsync(Customer customer)
        {
            return await PostRequest(customer.DeleteReturnObject() as Customer, true);
        }

        public async Task<Customer> DeactiveCustomerAsync(int customerId, int syncToken)
        {
            return await DeactiveCustomerAsync(new Customer
            {
                Id = customerId,
                SyncToken = syncToken
            });
        }

        public async Task<IBatchResponse<Customer>> DeactivateCustomersAsync(IEnumerable<Customer> customers)
        {
            return await BatchRequest<Customer>(customers.Select(x => x.DeleteReturnObject() as Customer), BatchOperation.Update);
        }

        public async Task<IBatchResponse<Customer>> DeactivateCustomersAsync(params Customer[] customers)
        {
            return await DeactivateCustomersAsync(customers.AsEnumerable());
        }
    }
}