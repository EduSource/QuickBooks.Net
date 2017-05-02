using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using QuickBooks.Net.Data.Models.Fields;
using QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line;

namespace QuickBooks.Net.Data.Models
{

    public enum EmailStatus
    {
        NotSet,
        NeedToSend,
        EmailSent
    }

    public enum PrintStatus
    {
        NotSet,
        NeedToPrint,
        PrintComplete
    }

    public enum GlobalTaxCalculation
    {
        TaxExcluded,
        TaxInclusive,
        NotApplicated
    }

    public class Invoice : QuickBooksBaseModel
    {

        [JsonProperty("CustomField", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<CustomField> CustomFields { get; set; }

        [JsonProperty("DocNumber", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string DocumentNumber { get; set; }

        [JsonProperty("TxnDate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? TransactionDate { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref DepartmentRef { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref CurrencyRef { get; set; }

        public decimal ExchangeRate { get; set; } = 1;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]        
        public string PrivateNote { get; set; }
    
        [JsonProperty("LinkedTxn", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<LinkedTransaction> LinkedTransactions { get; set; }

        [JsonProperty("Line", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<InvoiceLine> Lines { get; set; }

        [JsonProperty("TxnTaxDetail", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public TransactionTaxDetail TransactionTaxDetail { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref CustomerRef { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref CustomerMemo { get; set; }

        [JsonProperty("BillAddr", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Address BillingAddress { get; set; }

        [JsonProperty("ShipAddr", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Address ShippingAddress { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref ClassRef { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref SalesTermRef { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DueDate { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GlobalTaxCalculation? GlobalTaxCalculation { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref ShipMethodRef { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? ShipDate { get; set; }

        [JsonProperty("TrackingNum", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string TrackingNumber { get; set; }

        [JsonProperty("TotalAmt")]
        public decimal TotalAmount { get; set; }

        [JsonProperty("HomeTotalAmt")]
        public decimal HomeTotalAmount { get; set; }

        public bool ApplyTaxAfterDiscount { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]        
        public PrintStatus? PrintStatus { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public EmailStatus? EmailStatus { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public EmailAddress BillEmail { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public EmailAddress BillEmailCc { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public EmailAddress BillEmailBcc { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DeliveryInfo DeliveryInfo { get; set; }

        public decimal Balance { get; set; }

        public decimal HomeBalance { get; set; }

        [JsonProperty("TxnSource", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string TransactionSource { get; set; }

        public decimal Deposit { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string TransactionLocationType { get; set; }

        public bool AllowIPNPayment { get; set; }

        public bool AllowOnlinePayment { get; set; }

        public bool AllowOnlineCreditCardPayment { get; set; }

        public bool AllowOnlineACHPayment { get; set; }


        internal override QuickBooksBaseModel CreateReturnObject()
        {
            var invoice = new Invoice
            {
                CustomFields = CustomFields,
                DocumentNumber = DocumentNumber,
                TransactionDate = TransactionDate,
                DepartmentRef = DepartmentRef,
                CurrencyRef = CurrencyRef,
                ExchangeRate = ExchangeRate,
                PrivateNote = PrivateNote,
                LinkedTransactions = LinkedTransactions,
                Lines = Lines,
                TransactionTaxDetail = TransactionTaxDetail,
                CustomerRef = CustomerRef,
                CustomerMemo = CustomerMemo,
                BillingAddress = BillingAddress,
                ShippingAddress = ShippingAddress,
                ClassRef = ClassRef,
                SalesTermRef = SalesTermRef,
                DueDate = DueDate,
                GlobalTaxCalculation = GlobalTaxCalculation,
                ShipMethodRef = ShipMethodRef,
                ShipDate = ShipDate,
                TrackingNumber = TrackingNumber,
                TotalAmount = TotalAmount,
                HomeTotalAmount = HomeTotalAmount,
                ApplyTaxAfterDiscount = ApplyTaxAfterDiscount,
                PrintStatus = PrintStatus,
                EmailStatus = EmailStatus,
                BillEmail = BillEmail,
                BillEmailCc = BillEmailCc,
                BillEmailBcc = BillEmailBcc,
                DeliveryInfo = DeliveryInfo,
                Balance = Balance,
                HomeBalance = HomeBalance,
                TransactionSource = TransactionSource,
                Deposit = Deposit,
                TransactionLocationType = TransactionLocationType,
                AllowIPNPayment = AllowIPNPayment,
                AllowOnlinePayment = AllowOnlinePayment,
                AllowOnlineCreditCardPayment = AllowOnlineCreditCardPayment,
                AllowOnlineACHPayment = AllowOnlineACHPayment
            };

            return invoice;
        }

        internal override QuickBooksBaseModel UpdateReturnObject()
        {
            return this;
        }

        internal override QuickBooksBaseModel DeleteReturnObject()
        {
            return new Invoice
            {
                Id = Id,
                SyncToken = SyncToken
            };
        }

        // Void needs the same properties as Delete does
        internal QuickBooksBaseModel VoidReturnObject()
        {
            return DeleteReturnObject();
        }
    }
}
