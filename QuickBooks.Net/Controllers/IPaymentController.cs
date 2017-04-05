using System.Collections.Generic;
using System.Threading.Tasks;
using QuickBooks.Net.Data.Models;
using QuickBooks.Net.Data.Models.Batch;

namespace QuickBooks.Net.Controllers
{
    public interface IPaymentController
    {
        Task<Payment> GetPaymentAsync(int paymentId);

        Task<IEnumerable<Payment>> GetPaymentsAsync(int startPosition = 1, int maxResults = 100);

        Task<IEnumerable<Payment>> QueryPaymentsAsync(string query);

        Task<int> GetPaymentCountAsync();

        Task<Payment> CreatePaymentAsync(Payment payment);

        Task<IBatchResponse<Payment>> CreatePaymentsAsync(IEnumerable<Payment> payments);

        Task<IBatchResponse<Payment>> CreatePaymentsAsync(params Payment[] payments);

        Task<Payment> UpdatePaymentAsync(Payment payment);

        Task<IBatchResponse<Payment>> UpdatePaymentsAsync(IEnumerable<Payment> payments);

        Task<IBatchResponse<Payment>> UpdatePaymentsAsync(params Payment[] payments);

        Task<Payment> VoidPaymentAsync(Payment payment);

        Task<Payment> DeletePaymentAsync(Payment payment);

        Task<IBatchResponse<Payment>> DeletePaymentsAsync(IEnumerable<Payment> payments);

        Task<IBatchResponse<Payment>> DeletePaymentsAsync(params Payment[] payments);
        
    }
}
