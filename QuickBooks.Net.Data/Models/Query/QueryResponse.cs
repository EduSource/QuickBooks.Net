using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuickBooks.Net.Data.Models.Query
{
    public class QueryResponse<T>
    {
        [JsonProperty("QueryResponse")]
        private IDictionary<string, JToken> ResponseData { get; set; }

        [JsonIgnore]
        public IEnumerable<T> Data 
        {
            get
            {
                if(ResponseData.ContainsKey(typeof(T).Name))
                    return ResponseData[typeof(T).Name].ToObject<IEnumerable<T>>();
                else
                    return Enumerable.Empty<T>();
            }
        }

        public int Count
        {
            get
            {
                if (ResponseData.ContainsKey("totalCount"))
                    return ResponseData["totalCount"].ToObject<int>();
                else
                    return -1;
            }
        }
    }
}