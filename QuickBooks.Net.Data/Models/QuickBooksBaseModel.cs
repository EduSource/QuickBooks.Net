using System.ComponentModel;
using Newtonsoft.Json;
using QuickBooks.Net.Data.Models.Fields;

namespace QuickBooks.Net.Data.Models
{
    public abstract class QuickBooksBaseModel
    {

        [DefaultValue(-1)]
        [JsonProperty("Id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Id { get; set; } = -1;

        [JsonProperty("SyncToken", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? SyncToken { get; set; }

        [JsonProperty("sparse")]
        public bool Sparse { get; set; }

        [JsonProperty("domain", NullValueHandling = NullValueHandling.Ignore)]
        public string Domain { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] 
        public MetaData MetaData { get; internal set; }

        public abstract QuickBooksBaseModel CreateReturnObject();
        public abstract QuickBooksBaseModel UpdateReturnObject();
        public abstract QuickBooksBaseModel DeleteReturnObject();
    }
}