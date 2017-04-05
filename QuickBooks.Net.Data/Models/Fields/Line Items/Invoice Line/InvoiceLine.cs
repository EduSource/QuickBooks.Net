using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using QuickBooks.Net.Data.Extensions;
using QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line.Line_Details;

namespace QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line
{
    public enum LineDetailType
    {
        SalesItemLineDetail,
        GroupLineDetail,
        DescriptionOnly,
        DiscountLineDetail,
        SubTotalLineDetail,
        TaxLineDetail,
        DepositLineDetail
    }

    public class InvoiceLine : LineBase
    {

        [JsonProperty("Id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("LineNum", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public decimal LineNumber { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public LineDetailType DetailType { get; set; }

        [JsonExtensionData]
        private IDictionary<string, JToken> _lineDetailsDictionary;

        private LineDetailBase _lineDetails;

        [JsonIgnore]
        public LineDetailBase LineDetails
        {
            get
            {
                if (_lineDetails == null)
                {
                    var value = _lineDetailsDictionary[DetailType.ToString()];
                    _lineDetails = value.ToObject(DetailType.GetDetailType()) as LineDetailBase;
                }
                return _lineDetails;
            }
            set
            {
                if (_lineDetailsDictionary == null)
                {
                    _lineDetailsDictionary = new Dictionary<string, JToken>();
                }
                else
                {
                    _lineDetailsDictionary.Clear();
                }

                _lineDetails = value;
                DetailType = _lineDetails.Type;
                _lineDetailsDictionary[DetailType.ToString()] = JToken.FromObject(_lineDetails);
            }
        }

    }
}
