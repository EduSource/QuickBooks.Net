using System.Collections.Generic;
using System.Threading.Tasks;
using QuickBooks.Net.Data.Models;
using QuickBooks.Net.Data.Models.Batch;

namespace QuickBooks.Net.Controllers
{
    public interface IInvoiceController
    {

        Task<Invoice> GetInvoiceAsync(int invoiceId);

        Task<IEnumerable<Invoice>> GetInvoicesAsync(int startPosition = 1, int maxResults = 100);

        Task<IEnumerable<Invoice>> QueryInvoicesAsync(string query);

        Task<int> GetInvoiceCountAsync();

        Task<Invoice> CreateInvoiceAsync(Invoice invoice);

        Task<IBatchResponse<Invoice>> CreateInvoicesAsync(IEnumerable<Invoice> invoices);

        Task<IBatchResponse<Invoice>> CreateInvoicesAsync(params Invoice[] invoices);     

        Task<Invoice> UpdateInvoiceAsync(Invoice invoice);

        Task<IBatchResponse<Invoice>> UpdateInvoicesAsync(IEnumerable<Invoice> invoices);

        Task<IBatchResponse<Invoice>> UpdateInvoicesAsync(params Invoice[] invoices);     

        Task<Invoice> SendInvoiceAsync(Invoice invoice, string email = null);

        Task<Invoice> SendInvoiceAsync(int invoiceId, string email = null);

        Task<byte[]> DownloadInvoicePdf(Invoice invoice);

        Task<byte[]> DownloadInvoicePdf(int invoiceId);

        Task<Invoice> VoidInvoiceAsync(Invoice invoice);

        Task<Invoice> VoidInvoiceAsync(int invoiceId, int syncToken);

        Task<Invoice> DeleteInvoiceAsync(Invoice invoice);

        Task<Invoice> DeleteInvoiceAsync(int invoiceId, int syncToken);

        Task<IBatchResponse<Invoice>> DeleteInvoicesAsync(IEnumerable<Invoice> invoices);

        Task<IBatchResponse<Invoice>> DeleteInvoicesAsync(params Invoice[] invoices);        

    }
}
