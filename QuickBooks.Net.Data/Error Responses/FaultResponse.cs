using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuickBooks.Net.Data.Error_Responses
{
    public class FaultResponse
    {
        [JsonProperty("Error")]
        public List<ErrorDetailResponse> Errors;

        [JsonProperty("type")]
        public string Type;

        public FaultResponse()
        {
            Errors = new List<ErrorDetailResponse>();
        }

        public void AddError(string message, string detail, string errorCode = null)
        {
            Errors.Add(new ErrorDetailResponse
            {
                Message = message,
                Detail = detail,
                Code = errorCode
            });
        }

        public override string ToString()
        {
            return $"Type: {Type}, Errors: {string.Join(", ", Errors)}";
        }
    }
}
