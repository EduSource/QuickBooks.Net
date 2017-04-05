using Newtonsoft.Json;

namespace QuickBooks.Net.Data.Models.Fields
{
    public class Ref
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        public override string ToString()
        {
            return $"Name: {Name ?? "(null)"} - Value: {Value ?? "(null)"}";
        }
    }
}