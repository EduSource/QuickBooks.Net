using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickBooks.Net.Data.Models;
using QuickBooks.Net.Data.Models.Batch;

namespace QuickBooks.Net.Controllers
{
    public class PaymentController : BaseController, IPaymentController
    {
        protected override string ObjectName => "Payment";

        public PaymentController(QuickBooksClient client, string oAuthVersion) : base(client, oAuthVersion)
        {
        }

        public async Task<Payment> GetPaymentAsync(int paymentId)
        {
            return await GetRequest<Payment>(paymentId);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsAsync(int startPosition = 1, int maxResults = 100)
        {
            return await QueryRequest<Payment>("Select * From Payment", startPosition, maxResults);
        }

        public async Task<IEnumerable<Payment>> QueryPaymentsAsync(string query)
        {
            return await QueryRequest<Payment>(query, overrideOptions: true);
        }

        public async Task<int> GetPaymentCountAsync()
        {
            return await GetObjectCount<Payment>();
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            return await PostRequest(payment);
        }

        public async Task<IBatchResponse<Payment>> CreatePaymentsAsync(IEnumerable<Payment> payments)
        {
            return await BatchRequest<Payment>(payments, BatchOperation.Create);
        }

        public async Task<IBatchResponse<Payment>> CreatePaymentsAsync(params Payment[] payments)
        {
            return await CreatePaymentsAsync(payments.AsEnumerable());
        }

        public async Task<Payment> UpdatePaymentAsync(Payment payment)
        {
            return await PostRequest(payment, true);
        }

        public async Task<IBatchResponse<Payment>> UpdatePaymentsAsync(IEnumerable<Payment> payments)
        {
            return await BatchRequest<Payment>(payments, BatchOperation.Update);
        }

        public async Task<IBatchResponse<Payment>> UpdatePaymentsAsync(params Payment[] payments)
        {
            return await UpdatePaymentsAsync(payments.AsEnumerable());
        }

        public async Task<Payment> VoidPaymentAsync(Payment payment)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"include", "void"}
            };
            return await PostRequest(payment.VoidReturnObject() as Payment, additionalParams: queryParams);
        }

        public async Task<Payment> DeletePaymentAsync(Payment payment)
        {
            return await PostRequest(payment, delete: true);
        }

        public async Task<IBatchResponse<Payment>> DeletePaymentsAsync(IEnumerable<Payment> payments)
        {
            return await BatchRequest<Payment>(payments, BatchOperation.Delete);
        }

        public async Task<IBatchResponse<Payment>> DeletePaymentsAsync(params Payment[] payments)
        {
            return await UpdatePaymentsAsync(payments.AsEnumerable());
        }

    }
}
