using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuickBooks.Net.Data.Error_Responses;

namespace QuickBooks.Net.Data.Models.Batch
{
    public class BatchResponse<T> : IBatchResponse<T>
    {
        [JsonProperty("BatchItemResponse")]
        [JsonExtensionData(ReadData = true, WriteData = false)]
        private Dictionary<string, JToken> Response { get; set; }

        [JsonIgnore]
        public IEnumerable<T> Data
        {
            get
            {
                if(Response.ContainsKey("BatchItemResponse"))
                {
                    var batchItems = Response["BatchItemResponse"].ToList();
                    return batchItems.Where(x => x[typeof(T).Name] != null).Select(x => x[typeof(T).Name].ToObject<T>()).ToList();
                }

                return null;
            }
        }

        [JsonIgnore]
        public IEnumerable<QuickBooksErrorResponse> Errors
        {
            get
            {
                if(Response.ContainsKey("BatchItemResponse"))
                {
                    var batchItems = Response["BatchItemResponse"].ToList();
                    return batchItems.Where(x => x["Fault"] != null).Select(x => x.ToObject<QuickBooksErrorResponse>()).ToList();
                }
                return null;
            }
        }

    }
}