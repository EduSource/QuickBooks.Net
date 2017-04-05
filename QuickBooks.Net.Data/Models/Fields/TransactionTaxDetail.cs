using System.Collections.Generic;
using Newtonsoft.Json;
using QuickBooks.Net.Data.Models.Fields.Line_Items;

namespace QuickBooks.Net.Data.Models.Fields
{
    public class TransactionTaxDetail
    {

        [JsonProperty("TxnTaxCodeRef")]
        public Ref TransactionTaxCodeRef { get; set; }

        public decimal TotalTax { get; set; }

        [JsonProperty("TaxLine")]
        public List<TaxLine> TaxLines { get; set; }

    }
}
