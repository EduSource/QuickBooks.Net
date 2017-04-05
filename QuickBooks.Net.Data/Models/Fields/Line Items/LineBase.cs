using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuickBooks.Net.Data.Models.Fields.Line_Items
{
    public abstract class LineBase
    {

        public decimal Amount { get; set; }

        [JsonProperty("LinkedTxn")]
        public List<LinkedTransaction> LinkedTransactions { get; set; }

    }
}
