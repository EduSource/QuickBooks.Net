using System.Collections.Generic;
using System.Threading.Tasks;
using QuickBooks.Net.Data.Models;

namespace QuickBooks.Net.Controllers
{
    public class DepositController : BaseController, IDepositController
    {
        protected override string ObjectName => "Deposit";

        public DepositController(QuickBooksClient client, string oAuthVersion) : base(client, oAuthVersion)
        {
        }

        public async Task<Deposit> GetDepositAsync(int depositId)
        {
            return await GetRequest<Deposit>(depositId);
        }

        public async Task<IEnumerable<Deposit>> GetDepositsAsync(int startPosition = 1, int maxResults = 100)
        {
            return await QueryRequest<Deposit>("Select * From Deposit", startPosition, maxResults);
        }

        public async Task<IEnumerable<Deposit>> QueryDepositsAsync(string query)
        {
            return await QueryRequest<Deposit>(query, overrideOptions: true);
        }

        public async Task<int> GetDepositCountAsync()
        {
            return await GetObjectCount<Deposit>();
        }

        public async Task<Deposit> CreateDepositAsync(Deposit deposit)
        {
            return await PostRequest<Deposit>(deposit);
        }

        public async Task<Deposit> UpdateDepositAsync(Deposit deposit)
        {
            return await PostRequest<Deposit>(deposit, true);
        }

        public async Task<Deposit> DeleteDepositAsync(Deposit deposit)
        {
            return await PostRequest<Deposit>(deposit, delete: true);
        }

    }
}
