using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using QuickBooks.Net.Data.Models.Fields;
using QuickBooks.Net.Data.Models.Fields.Line_Items.Deposit_Line;

namespace QuickBooks.Net.Data.Models
{

    public enum PaymentStatus
    {
        Draft,
        Overdue,
        Pending,
        Payable,
        Paid,
        Trash,
        Unpaid
    }

    public class Deposit : QuickBooksBaseModel
    {

        [JsonProperty("TxnDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? TransactionDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Ref DepartmentRef { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GlobalTaxCalculation? GlobalTaxCalculation { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PrivateNote { get; set; }

        [JsonProperty("TxnStatus", NullValueHandling = NullValueHandling.Ignore)]
        public PaymentStatus TransactionStatus { get; set; }

        [JsonProperty("Line", NullValueHandling = NullValueHandling.Ignore)]
        public List<DepositLine> Lines { get; set; }

        [JsonProperty("TxnTaxDetail", NullValueHandling = NullValueHandling.Ignore)]
        public TransactionTaxDetail TransactionTaxDetail { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Ref DepositToAccountRef { get; set; }

        [JsonProperty("TxnSource", NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionSource { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CashBackInfo CashBack { get; set; }

        [JsonProperty("TotalAmt")]
        public decimal TotalAmount { get; set; }

        [JsonProperty("HomeTotalAmt")]
        public decimal HomeTotalAmount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionLocationType { get; set; }

        public override QuickBooksBaseModel CreateReturnObject()
        {
            throw new NotImplementedException();
        }

        public override QuickBooksBaseModel UpdateReturnObject()
        {
            throw new NotImplementedException();
        }

        public override QuickBooksBaseModel DeleteReturnObject()
        {
            throw new NotImplementedException();
        }
    }
}
