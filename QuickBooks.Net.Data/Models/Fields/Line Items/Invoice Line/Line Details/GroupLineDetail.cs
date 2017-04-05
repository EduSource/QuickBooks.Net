using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line.Line_Details
{
    public class GroupLineDetail : LineDetailBase
    {

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref GroupItemRef { get; set; }

        [JsonProperty("Qty")]
        public decimal Quantity { get; set; }

        [JsonProperty("Line", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<InvoiceLine> Lines { get; set; }

        public override LineDetailType Type { get { return LineDetailType.GroupLineDetail; } }
    }
}
