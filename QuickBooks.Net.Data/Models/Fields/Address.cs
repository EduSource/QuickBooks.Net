using Newtonsoft.Json;

namespace QuickBooks.Net.Data.Models.Fields
{
    public class Address
    {

        [JsonProperty("Id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Line1 { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Line2 { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Line3 { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Line4 { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Line5 { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CountrySubDivisionCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Lat { get; internal set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Long { get; internal set; }
    }
}