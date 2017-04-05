using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace QuickBooks.Net.Data.Models.Fields
{

    public enum CustomFieldTypeEnum
    {
        StringType
    }

    public class CustomField
    {
        [JsonProperty("DefinitionId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int DefinitionId { get; set; }

        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public CustomFieldTypeEnum? Type { get; set; }

        public string StringValue { get; set; }
    }
}
