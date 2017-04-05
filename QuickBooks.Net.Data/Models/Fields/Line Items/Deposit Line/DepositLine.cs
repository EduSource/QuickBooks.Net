using System.Collections.Generic;
using Newtonsoft.Json;
using QuickBooks.Net.Data.Models.Fields.Line_Items.Deposit_Line.Line_Details;
using QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line;

namespace QuickBooks.Net.Data.Models.Fields.Line_Items.Deposit_Line
{
    public class DepositLine : LineBase
    {

        [JsonProperty("Id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("LineNum")]
        public int LineNumber { get; set; }

        public string Description { get; set; }

        public readonly LineDetailType DetailType = LineDetailType.DepositLineDetail;

        public DepositLineDetail DepositLineDetail { get; set; }

        [JsonProperty("CustomField")]
        public List<CustomField> CustomFields { get; set; }

    }
}
