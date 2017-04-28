using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using QuickBooks.Net.Data.Models.Fields;

namespace QuickBooks.Net.Data.Models
{
    public enum PreferredDeliveryMethod
    {
        None,
        Print,
        Email
    }

    public class Customer : QuickBooksBaseModel
    {

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string GivenName { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string MiddleName { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string FamilyName { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Suffix { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string FullyQualifiedName { get; internal set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CompanyName { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PrintOnCheckName { get; set; }

        public bool Active { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PhoneNumber PrimaryPhone { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PhoneNumber AlternatePhone { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PhoneNumber Mobile { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PhoneNumber Fax { get; set; }
        
        [JsonProperty("PrimaryEmailAddr", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public EmailAddress PrimaryEmailAddress { get; set; }

        [JsonProperty("WebAddr", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public WebAddress WebAddress { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref DefaultTaxCodeRef { get; set; }

        public bool Taxable { get; set; }

        [JsonProperty("BillAddr", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Address BillingAddress { get; set; }

        [JsonProperty("ShipAddr", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Address ShippingAddress { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Notes { get; set; }

        public bool Job { get; set; }

        public bool BillWithParent { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref ParentRef { get; set; }

        public int Level { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref SalesTermRef { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref PaymentMethodRef { get; set; }

        public decimal Balance { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? OpenBalanceDate { get; set; }

        public decimal BalanceWithJobs { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref CurrencyRef { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PreferredDeliveryMethod? PreferredDeliveryMethod { get; set; }

        [JsonProperty("ResaleNum", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ResaleNumber { get; set; }

        [JsonProperty("ARAcocuntRef", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref ArAccountRef { get; set; }

        public override QuickBooksBaseModel CreateReturnObject()
        {
            var customer = new Customer
            {
                Title = Title,
                GivenName = GivenName,
                MiddleName = MiddleName,
                FamilyName = FamilyName,
                Suffix = Suffix,
                DisplayName = DisplayName,
                CompanyName = CompanyName,
                PrintOnCheckName = PrintOnCheckName,
                PrimaryPhone = PrimaryPhone,
                AlternatePhone = AlternatePhone,
                Mobile = Mobile,
                Fax = Fax,
                PrimaryEmailAddress = PrimaryEmailAddress,
                WebAddress = WebAddress,
                Taxable = Taxable,
                BillingAddress = BillingAddress,
                ShippingAddress = ShippingAddress,
                Notes = Notes,
                Job = Job,
                ParentRef = ParentRef,
                Level = Level,
                Balance = Balance,
                OpenBalanceDate = OpenBalanceDate,
                BalanceWithJobs = BalanceWithJobs,
                PreferredDeliveryMethod = PreferredDeliveryMethod,
                ResaleNumber = ResaleNumber,
            };

            if (!customer.Job && customer.ParentRef != null)
                customer.ParentRef = null;

            return customer;
        }

        public override QuickBooksBaseModel UpdateReturnObject()
        {
            return this;
        }

        public override QuickBooksBaseModel DeleteReturnObject()
        {
            return new Customer
            {
                Id = Id,
                DisplayName = DisplayName,
                SyncToken = SyncToken,
                Active = false
            };
        }
    }
}