using System.Threading.Tasks;
using QuickBooks.Net.Controllers;
using QuickBooks.Net.Data.Models;
using QuickBooks.Net.Data.Models.Authorization;

namespace QuickBooks.Net
{
    public interface IQuickBooksClient
    {
        string ConsumerKey { get; set; }
        string ConsumerSecret { get; set; }
        string AccessToken { get; set; }
        string AccessTokenSecret { get; set; }
        string CallbackUrl { get; set; }
        bool SandboxMode { get; set; }
        string RealmId { get; set; }
        string MinorVersion { get; set; }
        string AcceptType { get; set; }

        ICustomerController Customers { get; }
        ICompanyInfoController CompanyInfo { get; }
        IInvoiceController Invoices { get; }
        IPaymentController Payments { get; }
        IDepositController Deposits { get; }
        ISalesReceiptController SalesReceipts { get; }

        Task<QuickBooksUser> GetCurrentUser();
        Task DisconnectAccount();
        Task ReconnectAccount();
        Task<AuthTokenInfo> GetAuthTokens();
        Task<AccessTokenInfo> RequestAccessTokens(string authToken, string authTokenSecret, string oauthVerifier);
    }
}