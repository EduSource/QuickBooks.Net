using Newtonsoft.Json;

namespace QuickBooks.Net.Data.Models.Fields
{

    public class LinkedTransaction
    {
        [JsonProperty("TxnId")]
        public string TransactionId { get; set; }

        [JsonProperty("TxnType")]
        public string TransactionType { get; set; }

        [JsonProperty("TxnLineId")]
        public string TransactionLineId { get; set; }
    }
}
