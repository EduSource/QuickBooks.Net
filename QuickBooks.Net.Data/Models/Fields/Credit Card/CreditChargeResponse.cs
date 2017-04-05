using System;
using Newtonsoft.Json;

namespace QuickBooks.Net.Data.Models.Fields.Credit_Card
{

    public enum CcPaymentStatus
    {
        Unknown,
        Completed
    }

    public class CreditChargeResponse
    {

        [JsonProperty("CCTransId")]
        public string CcTransId { get; set; }

        public string AuthCode { get; set; }

        [JsonProperty("TxnAuthorizationTime")]
        public DateTime TransactionAuthorizationTime { get; set; }

        public CcPaymentStatus Status { get; set; }
    }
}
