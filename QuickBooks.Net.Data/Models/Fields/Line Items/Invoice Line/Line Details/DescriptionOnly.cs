using System;
using Newtonsoft.Json;

namespace QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line.Line_Details
{
    public class DescriptionOnly
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? Date { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref TaxCodeRef { get; set; }
    }
}
