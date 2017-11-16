using System.ComponentModel;
using Newtonsoft.Json;
using QuickBooks.Net.Data.Models.Fields;

namespace QuickBooks.Net.Data.Models
{
    public abstract class QuickBooksBaseModelString
    {

        [JsonProperty("Id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("SyncToken", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? SyncToken { get; set; }

        [JsonProperty("sparse")]
        public bool Sparse { get; set; }

        [JsonProperty("domain", NullValueHandling = NullValueHandling.Ignore)]
        public string Domain { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public MetaData MetaData { get; internal set; }

        internal abstract QuickBooksBaseModelString CreateReturnObject();
        internal abstract QuickBooksBaseModelString UpdateReturnObject();
        internal abstract QuickBooksBaseModelString DeleteReturnObject();
    }
}