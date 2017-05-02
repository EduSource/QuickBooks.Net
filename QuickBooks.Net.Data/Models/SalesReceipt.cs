using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QuickBooks.Net.Data.Models.Fields;
using QuickBooks.Net.Data.Models.Fields.Line_Items.Invoice_Line;

namespace QuickBooks.Net.Data.Models
{
    public class SalesReceipt : QuickBooksBaseModel
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref CustomerRef { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref ClassRef { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PaymentRefNum { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref PaymentMethodRef { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool ApplyTaxAfterDiscount { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref DepositToAccountRef { get; set; }

        [JsonProperty("BillAddr", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Address BillingAddress { get; set; }

        [JsonProperty("ShipAddr", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Address ShippingAddress { get; set; }

        [JsonProperty("Line", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<InvoiceLine> Lines { get; set; }

        internal override QuickBooksBaseModel CreateReturnObject()
        {
            var salesReceipt = new SalesReceipt()
            {
                ApplyTaxAfterDiscount = ApplyTaxAfterDiscount,
                BillingAddress = BillingAddress,
                ClassRef = ClassRef,
                CustomerRef = CustomerRef,
                DepositToAccountRef = DepositToAccountRef,
                Lines = Lines,
                PaymentMethodRef = PaymentMethodRef,
                PaymentRefNum = PaymentRefNum,
                ShippingAddress = ShippingAddress,
            };

            return salesReceipt;
        }

        internal override QuickBooksBaseModel DeleteReturnObject()
        {
            return new SalesReceipt()
            {
                Id = Id,
                SyncToken = SyncToken
            };
        }

        internal override QuickBooksBaseModel UpdateReturnObject()
        {
            return this;
        }

        // Void needs the same properties as Delete does
        internal QuickBooksBaseModel VoidReturnObject()
        {
            return DeleteReturnObject();
        }
    }
}
