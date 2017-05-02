using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using QuickBooks.Net.Data.Models.Fields;

namespace QuickBooks.Net.Data.Models
{

    public enum Month
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    public class CompanyInfo : QuickBooksBaseModel
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string LegalName { get; set; }

        [JsonProperty("CompanyAddr", NullValueHandling = NullValueHandling.Ignore)]
        public Address CompanyAddress { get; set; }

        [JsonProperty("CustomerCommunicationAddr", NullValueHandling = NullValueHandling.Ignore)]
        public Address CustomerCommunicationAddress { get; set; }

        [JsonProperty("LegalAddr", NullValueHandling = NullValueHandling.Ignore)]
        public Address LegalAddress { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PhoneNumber PrimaryPhone { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CompanyStartDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Month? FiscalYearStartMonth { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public EmailAddress Email { get; set; }

        [JsonProperty("WebAddr", NullValueHandling = NullValueHandling.Ignore)]
        public WebAddress WebAddress { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SupportedLanguages { get; set; }

        [JsonProperty("NameValue", NullValueHandling = NullValueHandling.Ignore)]
        public List<NameValuePair<string, string>> NameValues { get; set; }

        // Can't create company info
        internal override QuickBooksBaseModel CreateReturnObject()
        {
            throw new NotImplementedException();
        }

        // Can't update company info
        internal override QuickBooksBaseModel UpdateReturnObject()
        {
            throw new NotImplementedException();
        }

        // Can't delete company info
        internal override QuickBooksBaseModel DeleteReturnObject()
        {
            throw new NotImplementedException();
        }
    }
}
