using System.Collections.Generic;
using System.Threading.Tasks;
using QuickBooks.Net.Data.Models;
using QuickBooks.Net.Data.Models.Batch;

namespace QuickBooks.Net.Controllers
{
    public interface ISalesReceiptController
    {

        Task<SalesReceipt> GetSalesReceiptAsync(int receiptId);

        Task<IEnumerable<SalesReceipt>> GetSalesReceiptsAsync(int startPosition = 1, int maxResults = 100);

        Task<IEnumerable<SalesReceipt>> QuerySalesReceiptsAsync(string query);

        Task<int> GetSalesReceiptCountAsync();

        Task<SalesReceipt> CreateSalesReceiptAsync(SalesReceipt receipt);

        Task<IBatchResponse<SalesReceipt>> CreateSalesReceiptsAsync(IEnumerable<SalesReceipt> receipts);

        Task<IBatchResponse<SalesReceipt>> CreateSalesReceiptsAsync(params SalesReceipt[] receipts);     

        Task<SalesReceipt> UpdateSalesReceiptAsync(SalesReceipt receipt);

        Task<IBatchResponse<SalesReceipt>> UpdateSalesReceiptsAsync(IEnumerable<SalesReceipt> receipts);

        Task<IBatchResponse<SalesReceipt>> UpdateSalesReceiptsAsync(params SalesReceipt[] receipts);     

        Task<SalesReceipt> SendSalesReceiptAsync(SalesReceipt receipt, string email = null);

        Task<SalesReceipt> SendSalesReceiptAsync(int receiptId, string email = null);

        Task<byte[]> DownloadSalesReceiptPdf(SalesReceipt receipt);

        Task<byte[]> DownloadSalesReceiptPdf(int receiptId);

        Task<SalesReceipt> VoidSalesReceiptAsync(SalesReceipt receipt);

        Task<SalesReceipt> VoidSalesReceiptAsync(int receiptId, int syncToken);

        Task<SalesReceipt> DeleteSalesReceiptAsync(SalesReceipt receipt);

        Task<SalesReceipt> DeleteSalesReceiptAsync(int receiptId, int syncToken);

        Task<IBatchResponse<SalesReceipt>> DeleteSalesReceiptsAsync(IEnumerable<SalesReceipt> receipts);

        Task<IBatchResponse<SalesReceipt>> DeleteSalesReceiptsAsync(params SalesReceipt[] receipts);        

    }
}
