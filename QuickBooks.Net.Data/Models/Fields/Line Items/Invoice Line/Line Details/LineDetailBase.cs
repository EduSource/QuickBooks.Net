using Newtonsoft.Json;

namespace QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line.Line_Details
{
    public abstract class LineDetailBase
    {
        [JsonIgnore]
        public abstract LineDetailType Type { get; }
    }
}
