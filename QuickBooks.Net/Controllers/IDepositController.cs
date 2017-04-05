using System.Collections.Generic;
using System.Threading.Tasks;
using QuickBooks.Net.Data.Models;

namespace QuickBooks.Net.Controllers
{
    public interface IDepositController
    {
        Task<Deposit> GetDepositAsync(int depositId);

        Task<IEnumerable<Deposit>> GetDepositsAsync(int startPosition = 1, int maxResults = 100);

        Task<IEnumerable<Deposit>> QueryDepositsAsync(string query);

        Task<int> GetDepositCountAsync();

        Task<Deposit> CreateDepositAsync(Deposit deposit);

        Task<Deposit> UpdateDepositAsync(Deposit deposit);

        Task<Deposit> DeleteDepositAsync(Deposit deposit);

    }
}
