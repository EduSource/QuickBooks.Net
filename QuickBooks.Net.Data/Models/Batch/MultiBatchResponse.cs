using System.Collections.Generic;
using QuickBooks.Net.Data.Error_Responses;

namespace QuickBooks.Net.Data.Models.Batch
{
    public class MultiBatchResponse<T> : IBatchResponse<T>
    {
        public List<BatchResponse<T>> responses { get; set; }

        public IEnumerable<T> Data
        {
            get
            {
                var data = new List<T>();
                responses.ForEach((response) => {
                    data.AddRange(response.Data);
                });
                return data;
            }
        }

        public IEnumerable<QuickBooksErrorResponse> Errors
        {
            get
            {
                var errors = new List<QuickBooksErrorResponse>();
                responses.ForEach((response) => {
                    errors.AddRange(response.Errors);
                });
                return errors;
            }
        }

        public MultiBatchResponse()
        {
            this.responses = new List<BatchResponse<T>>();
        }
    }
}