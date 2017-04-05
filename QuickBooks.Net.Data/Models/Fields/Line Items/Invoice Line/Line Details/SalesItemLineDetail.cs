using Newtonsoft.Json;

namespace QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line.Line_Details
{
    public class SalesItemLineDetail : LineDetailBase
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref ItemRef { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref ClassRef { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public decimal UnitPrice { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public MarkupInfo MarkupInfo { get; set; }

        [JsonProperty("Qty", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public decimal Quantity { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref TaxCodeRef { get; set; }

        [JsonProperty("TaxInclusiveAmt", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public decimal TaxInclusiveAmount { get; set; }

        public override LineDetailType Type { get { return LineDetailType.SalesItemLineDetail; } }
    }
}
