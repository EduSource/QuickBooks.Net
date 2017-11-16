using Newtonsoft.Json;
using QuickBooks.Net.Data.Models.Fields;

namespace QuickBooks.Net.Data.Models
{
    public class Class : QuickBooksBaseModelString
    {

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool SubClass { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ref ParentRef { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string FullyQualifiedName { get; set; }

        public bool Active { get; set; }

        internal override QuickBooksBaseModelString CreateReturnObject()
        {
            return new Class
            {
                Id = Id,
                Name = Name,
                SubClass = SubClass,
                ParentRef = ParentRef,
                FullyQualifiedName = FullyQualifiedName,
                Active = Active
            };
        }

        internal override QuickBooksBaseModelString UpdateReturnObject()
        {
            return this;
        }

        internal override QuickBooksBaseModelString DeleteReturnObject()
        {
            return new Class
            {
                Id = Id,
                SyncToken = SyncToken,
                Active = false,
                Name = Name
            };
        }
    }
}
