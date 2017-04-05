using System.Linq;
using System.Threading.Tasks;
using QuickBooks.Net.Data.Models;

namespace QuickBooks.Net.Controllers
{
    public class CompanyInfoController : BaseController, ICompanyInfoController
    {
        protected override string ObjectName => "CompanyInfo";

        public CompanyInfoController(QuickBooksClient client, string oAuthVersion) : base(client, oAuthVersion)
        {
        }

        public async Task<CompanyInfo> GetCompanyInfoAsync()
        {
            return await GetRequest<CompanyInfo>(Client.RealmId);
        }

        public async Task<CompanyInfo> QueryCompanyInfoAsync(string query)
        {
            var result =  await QueryRequest<CompanyInfo>(query);
            return result.FirstOrDefault();
        }
    }
}
