using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line;
using QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line.Line_Details;

namespace QuickBooks.Net.Data.Models.Fields.Line_Items.Deposit_Line.Line_Details
{

    public enum TransactionType
    {
        APCreditCard,
        ARRefundCreditCard,
        Bill,
        BillPaymentCheck,
        BuildAssembly,
        CarryOver,
        CashPurchase,
        Charge,
        Check,
        CreditMemo,
        Deposit,
        EFPLiabilityCheck,
        EFTBillPayment,
        EFTRefund,
        Estimate,
        InventoryAdjustment,
        InventoryTransfer,
        Invoice,
        ItemReceipt,
        JournalEntry,
        LiabilityAdjustment,
        Paycheck,
        PayrollLiabilityCheck,
        Purchase,
        PurchaseOrder,
        PriorPayment,
        ReceivePayment,
        RefundCheck,
        RefundReceipt,
        SalesOrder,
        SalesReceipt,
        SalesTaxPaymentCheck,
        Transfer,
        TimeActivity,
        VendorCredit,
        YTDAdjustment
    }

    public enum TaxApplicableOn
    {
        Sales,
        Purchase
    }

    public class DepositLineDetail : LineDetailBase
    {

        public override LineDetailType Type { get { return LineDetailType.DepositLineDetail; } }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref Entity { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref ClassRef { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref AccountRef { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref PaymentMethodRef { get; set; }

        [JsonProperty("CheckNum", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CheckNumber { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionType? TransactionType { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref TaxCodeRef { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public TaxApplicableOn? TaxApplicableOn { get; set; }
    }
}
