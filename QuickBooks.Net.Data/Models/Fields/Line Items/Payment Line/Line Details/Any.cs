using Newtonsoft.Json;

namespace QuickBooks.Net.Data.Models.Fields.Line_Items.Payment_Line.Line_Details
{
    public class Any
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("declaredType")]
        public string DeclaredType { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("value")]
        public Ref Value { get; set; }

        [JsonProperty("nil")]
        public bool Nil { get; set; }

        [JsonProperty("globalScope")]
        public bool GlobalScope { get; set; }

        [JsonProperty("typeSubstituted")]
        public bool TypeSubstituted { get; set; }

    }
}
