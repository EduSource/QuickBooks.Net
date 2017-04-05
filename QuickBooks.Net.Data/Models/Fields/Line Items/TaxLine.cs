using Newtonsoft.Json;
using QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line;
using QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line.Line_Details;

namespace QuickBooks.Net.Data.Models.Fields.Line_Items
{
    public class TaxLine : LineBase
    {

        public readonly LineDetailType DetailType = LineDetailType.TaxLineDetail;

        [JsonProperty("TaxLineDetail")]
        public TaxLineDetail TaxLineDetails { get; set; }

    }
}
