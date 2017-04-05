using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuickBooks.Net.Data.Models.Batch
{

    public enum BatchOperation
    {
        Create,
        Update,
        Delete
    }

    public class BatchItem
    {
        [JsonProperty("bId")]
        public string BatchId { get; internal set; }

        [JsonProperty("operation", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _operation;

        [JsonIgnore]
        public BatchOperation? Operation { 
            get 
            { 
                return (BatchOperation) Enum.Parse(typeof(BatchOperation), _operation, true); 
            } 
            set 
            { 
                if(value != null)
                    _operation = value.ToString().ToLower(); 
            } 
        }

        [JsonIgnore]
        public object Data { get; set; }

        [JsonExtensionData(WriteData = true, ReadData = false)]
        private IDictionary<string, JToken> DataToSerialize 
        {
            get 
            { 
                var returnDictionary = new Dictionary<string, JToken>();
                returnDictionary.Add(Data.GetType().Name, JToken.FromObject(Data));
                return returnDictionary;
            }
        }
    }
}