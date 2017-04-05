using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickBooks.Net.Data.Models;
using QuickBooks.Net.Data.Models.Batch;

namespace QuickBooks.Net.Controllers
{
    public class InvoiceController : BaseController, IInvoiceController
    {
        protected override string ObjectName => "Invoice";

        public InvoiceController(QuickBooksClient client, string oAuthVersion) : base(client, oAuthVersion)
        {
        }

        public async Task<Invoice> GetInvoiceAsync(int invoiceId)
        {
            return await GetRequest<Invoice>(invoiceId);
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesAsync(int startPosition = 1, int maxResults = 100)
        {
            return await QueryRequest<Invoice>("Select * From Invoice", startPosition, maxResults);
        }

        public async Task<IEnumerable<Invoice>> QueryInvoicesAsync(string query)
        {
            return await QueryRequest<Invoice>(query, overrideOptions: true);
        }

        public async Task<int> GetInvoiceCountAsync()
        {
            return await GetObjectCount<Invoice>();
        }

        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
        {
            return await PostRequest(invoice.CreateReturnObject() as Invoice);
        }

        public async Task<IBatchResponse<Invoice>> CreateInvoicesAsync(IEnumerable<Invoice> invoices)
        {
            return await BatchRequest<Invoice>(invoices, BatchOperation.Create);
        }

        public async Task<IBatchResponse<Invoice>> CreateInvoicesAsync(params Invoice[] invoices)
        {
            return await CreateInvoicesAsync(invoices.AsEnumerable());
        }

        public async Task<Invoice> UpdateInvoiceAsync(Invoice invoice)
        {
            return await PostRequest(invoice.UpdateReturnObject() as Invoice, true);
        }

        public async Task<IBatchResponse<Invoice>> UpdateInvoicesAsync(IEnumerable<Invoice> invoices)
        {
            return await BatchRequest<Invoice>(invoices, BatchOperation.Update);
        }

        public async Task<IBatchResponse<Invoice>> UpdateInvoicesAsync(params Invoice[] invoices)
        {
            return await UpdateInvoicesAsync(invoices.AsEnumerable());
        }

        public async Task<Invoice> SendInvoiceAsync(Invoice invoice, string email = null)
        {
            return await SendInvoiceAsync(invoice.Id, email);
        }

        public async Task<Invoice> SendInvoiceAsync(int invoiceId, string email = null)
        {
            var additionalParams = !string.IsNullOrEmpty(email)
                ? new Dictionary<string, string>
                    {
                        {"sendTo", email}
                    }
                : null;

            return await SendEmailRequest<Invoice>($"{invoiceId}/send", additionalParams: additionalParams);
        }

        public async Task<byte []> DownloadInvoicePdf(Invoice invoice)
        {
            return await DownloadInvoicePdf(invoice.Id);
        }

        public async Task<byte []> DownloadInvoicePdf(int invoiceId)
        {
            var resourceUrl = $"{ObjectName.ToLower()}/{invoiceId}/pdf";
            return await DownloadFile(resourceUrl, "application/pdf");
        }

        public async Task<Invoice> VoidInvoiceAsync(Invoice invoice)
        {
            return await PostRequest(invoice.VoidReturnObject() as Invoice,
                additionalParams: new Dictionary<string, string>
                {
                    { "operation", "void" }
                });
        }

        public async Task<Invoice> VoidInvoiceAsync(int invoiceId, int syncToken)
        {
            return await VoidInvoiceAsync(new Invoice
            {
                Id = invoiceId, SyncToken = syncToken
            });
        }

        public async Task<Invoice> DeleteInvoiceAsync(Invoice invoice)
        {
            return await PostRequest(invoice.DeleteReturnObject() as Invoice, delete: true);
        }

        public async Task<Invoice> DeleteInvoiceAsync(int invoiceId, int syncToken)
        {
            return await DeleteInvoiceAsync(new Invoice
            {
                Id = invoiceId,
                SyncToken = syncToken
            });
        }

        public async Task<IBatchResponse<Invoice>> DeleteInvoicesAsync(IEnumerable<Invoice> invoices)
        {
            return await BatchRequest<Invoice>(invoices, BatchOperation.Delete);
        }

        public async Task<IBatchResponse<Invoice>> DeleteInvoicesAsync(params Invoice[] invoices)
        {
            return await DeleteInvoicesAsync(invoices.AsEnumerable());
        }

    }
}
