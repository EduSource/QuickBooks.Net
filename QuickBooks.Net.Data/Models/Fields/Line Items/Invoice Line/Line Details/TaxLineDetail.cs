using Newtonsoft.Json;

namespace QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line.Line_Details
{
    public class TaxLineDetail : LineDetailBase
    {
        public bool PercentBased { get; set; }

        public decimal NetAmountTaxable { get; set; }

        public decimal TaxInclusiveAmount { get; set; }

        public decimal OverrideDeltaAmount { get; set; }

        public decimal TaxPercent { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref TaxRateRef { get; set; }

        public override LineDetailType Type { get { return LineDetailType.TaxLineDetail; } }
    }
}
