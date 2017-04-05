using Newtonsoft.Json;

namespace QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line.Line_Details
{
    public class SubtotalLineDetail : LineDetailBase
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref ItemRef { get; set; }

        public override LineDetailType Type { get { return LineDetailType.SubTotalLineDetail; } }
    }
}
