using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QuickBooks.Net.Data.Models.Fields;
using QuickBooks.Net.Data.Models.Fields.Credit_Card;
using QuickBooks.Net.Data.Models.Fields.Line_Items.Payment_Line;

namespace QuickBooks.Net.Data.Models
{
    public class Payment : QuickBooksBaseModel
    {

        [JsonProperty("TxnDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? TransactionDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Ref CurrencyRef { get; set; }

        public decimal ExchangeRate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PrivateNote { get; set; }

        [JsonProperty("TxnStatus", NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionStatus { get; set; }

        [JsonProperty("Line", NullValueHandling = NullValueHandling.Ignore)]
        public List<PaymentLine> Lines { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Ref CustomerRef { get; set; }

        [JsonProperty("ARAccountRef", NullValueHandling = NullValueHandling.Ignore)]
        public Ref AccountsReceivableAccountRef { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Ref DepositToAccountRef { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Ref PaymentMethodRef { get; set; }

        [JsonProperty("PaymentRefNum", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentRefNumber { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CreditChargeResponse CreditChargeResponse { get; set; }

        [JsonProperty("TxnSource", NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionSource { get; set; }

        [JsonProperty("TotalAmt")]
        public decimal TotalAmount { get; set; }

        [JsonProperty("UnappliedAmt")]
        public decimal UnappliedAmount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionLocationType { get; set; }

        internal override QuickBooksBaseModel CreateReturnObject()
        {
            throw new NotImplementedException();
        }

        internal override QuickBooksBaseModel UpdateReturnObject()
        {
            throw new NotImplementedException();
        }

        internal QuickBooksBaseModel VoidReturnObject()
        {
            return new Payment
            {
                Id = Id,
                Sparse = true,
                SyncToken = SyncToken
            };
        }

        internal override QuickBooksBaseModel DeleteReturnObject()
        {
            throw new NotImplementedException();
        }
    }
}
