using Newtonsoft.Json;

namespace QuickBooks.Net.Data.Error_Responses
{
    public class ErrorDetailResponse
    {
        public string Message;

        public string Detail;

        [JsonProperty("code")]
        public string Code;

        [JsonProperty("element")]
        public string Element;

        public override string ToString()
        {
            return $"Message: {Message}, Detail: {Detail}, Code: {Code}, Element: {Element}";
        }
    }
}
