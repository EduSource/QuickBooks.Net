using Newtonsoft.Json;

namespace QuickBooks.Net.Data.Models.Fields
{
    public class WebAddress
    {
        [JsonProperty("URI")]
        public string Uri { get; set; }

        public override string ToString()
        {
            return Uri;
        }
    }
}