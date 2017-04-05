using System.Threading.Tasks;
using QuickBooks.Net.Data.Models;

namespace QuickBooks.Net.Controllers
{
    public interface ICompanyInfoController
    {

        Task<CompanyInfo> GetCompanyInfoAsync();

        Task<CompanyInfo> QueryCompanyInfoAsync(string query);

    }
}
