using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System;

namespace QuickBooks.Net.Data.Models.Batch
{
    public class BatchItemRequest
    {
        [JsonProperty("BatchItemRequest")]
        public List<BatchItem> BatchItems = new List<BatchItem>();

        public BatchItemRequest()
        {
        }

        public BatchItemRequest(IEnumerable<object> items, BatchOperation? operation = null)
        {
            PopulateItems(items, operation);
        }

        public BatchItemRequest PopulateItems(IEnumerable<object> items, BatchOperation? operation = null)
        {
            BatchItems.AddRange(items.Select(x => new BatchItem
            {
                Data = x,
                Operation = operation,
                BatchId = Guid.NewGuid().ToString()
            }));
            return this;
        }

        public BatchItemRequest Add(object item, BatchOperation? operation = null)
        {
            BatchItems.Add(new BatchItem
            {
                Data = item,
                Operation = operation,
                BatchId = $"bId{BatchItems.Count}"
            });

            return this;
        }

    }
}