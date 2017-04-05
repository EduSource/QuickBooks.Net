using Newtonsoft.Json;

namespace QuickBooks.Net.Data.Models.Fields.Credit_Card
{
    public class CreditChargeInfo
    {

        public string Type { get; set; }

        [JsonProperty("NameOnAcct")]
        public string NameOnAccount { get; set; }

        public int CcExpiryMonth { get; set; }

        [JsonProperty("BillAddrStreet")]
        public string BillingAddressStreet { get; set; }

        public string PostalCode { get; set; }

        public decimal Amount { get; set; }

        public bool ProcessPayment { get; set; }
    }
}
