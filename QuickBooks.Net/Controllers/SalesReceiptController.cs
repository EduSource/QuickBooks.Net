using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickBooks.Net.Data.Models;
using QuickBooks.Net.Data.Models.Batch;

namespace QuickBooks.Net.Controllers
{
    public class SalesReceiptController : BaseController, ISalesReceiptController
    {
        protected override string ObjectName => "SalesReceipt";

        public SalesReceiptController(QuickBooksClient client, string oAuthVersion) : base(client, oAuthVersion)
        {
        }

        public async Task<SalesReceipt> GetSalesReceiptAsync(int receiptId)
        {
            return await GetRequest<SalesReceipt>(receiptId);
        }

        public async Task<IEnumerable<SalesReceipt>> GetSalesReceiptsAsync(int startPosition = 1, int maxResults = 100)
        {
            return await QueryRequest<SalesReceipt>("Select * From SalesReceipt ", startPosition, maxResults);
        }

        public async Task<IEnumerable<SalesReceipt>> QuerySalesReceiptsAsync(string query)
        {
            return await QueryRequest<SalesReceipt>(query, overrideOptions: true);
        }

        public async Task<int> GetSalesReceiptCountAsync()
        {
            return await GetObjectCount<SalesReceipt>();
        }

        public async Task<SalesReceipt> CreateSalesReceiptAsync(SalesReceipt receipt)
        {
            return await PostRequest(receipt.CreateReturnObject() as SalesReceipt);
        }

        public async Task<IBatchResponse<SalesReceipt>> CreateSalesReceiptsAsync(IEnumerable<SalesReceipt> receipts)
        {
            return await BatchRequest<SalesReceipt>(receipts, BatchOperation.Create);
        }

        public async Task<IBatchResponse<SalesReceipt>> CreateSalesReceiptsAsync(params SalesReceipt[] receipts)
        {
            return await CreateSalesReceiptsAsync(receipts.AsEnumerable());
        }

        public async Task<SalesReceipt> UpdateSalesReceiptAsync(SalesReceipt receipt)
        {
            return await PostRequest(receipt.UpdateReturnObject() as SalesReceipt, true);
        }

        public async Task<IBatchResponse<SalesReceipt>> UpdateSalesReceiptsAsync(IEnumerable<SalesReceipt> receipts)
        {
            return await BatchRequest<SalesReceipt>(receipts, BatchOperation.Update);
        }

        public async Task<IBatchResponse<SalesReceipt>> UpdateSalesReceiptsAsync(params SalesReceipt[] receipts)
        {
            return await UpdateSalesReceiptsAsync(receipts.AsEnumerable());
        }

        public async Task<SalesReceipt> SendSalesReceiptAsync(SalesReceipt receipt, string email = null)
        {
            return await SendSalesReceiptAsync(receipt.Id, email);
        }

        public async Task<SalesReceipt> SendSalesReceiptAsync(int receiptId, string email = null)
        {
            var additionalParams = !string.IsNullOrEmpty(email)
                ? new Dictionary<string, string>
                    {
                        {"sendTo", email}
                    }
                : null;

            return await SendEmailRequest<SalesReceipt>($"{receiptId}/send", additionalParams: additionalParams);
        }

        public async Task<byte []> DownloadSalesReceiptPdf(SalesReceipt receipt)
        {
            return await DownloadSalesReceiptPdf(receipt.Id);
        }

        public async Task<byte []> DownloadSalesReceiptPdf(int receiptId)
        {
            var resourceUrl = $"{ObjectName.ToLower()}/{receiptId}/pdf";
            return await DownloadFile(resourceUrl, "application/pdf");
        }

        public async Task<SalesReceipt> VoidSalesReceiptAsync(SalesReceipt receipt)
        {
            return await PostRequest(receipt.VoidReturnObject() as SalesReceipt,
                additionalParams: new Dictionary<string, string>
                {
                    { "operation", "void" }
                });
        }

        public async Task<SalesReceipt> VoidSalesReceiptAsync(int receiptId, int syncToken)
        {
            return await VoidSalesReceiptAsync(new SalesReceipt
            {
                Id = receiptId, SyncToken = syncToken
            });
        }

        public async Task<SalesReceipt> DeleteSalesReceiptAsync(SalesReceipt receipt)
        {
            return await PostRequest(receipt.DeleteReturnObject() as SalesReceipt, delete: true);
        }

        public async Task<SalesReceipt> DeleteSalesReceiptAsync(int receiptId, int syncToken)
        {
            return await DeleteSalesReceiptAsync(new SalesReceipt
            {
                Id = receiptId,
                SyncToken = syncToken
            });
        }

        public async Task<IBatchResponse<SalesReceipt>> DeleteSalesReceiptsAsync(IEnumerable<SalesReceipt> receipts)
        {
            return await BatchRequest<SalesReceipt>(receipts, BatchOperation.Delete);
        }

        public async Task<IBatchResponse<SalesReceipt>> DeleteSalesReceiptsAsync(params SalesReceipt[] receipts)
        {
            return await DeleteSalesReceiptsAsync(receipts.AsEnumerable());
        }

    }
}
