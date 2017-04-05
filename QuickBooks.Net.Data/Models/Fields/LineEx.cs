using System.Collections.Generic;
using Newtonsoft.Json;
using QuickBooks.Net.Data.Models.Fields.Line_Items.Payment_Line.Line_Details;

namespace QuickBooks.Net.Data.Models.Fields
{
    public class LineEx
    {

        [JsonProperty("any")]
        public List<Any> Any { get; set; }

    }
}
