using Newtonsoft.Json;
using QuickBooks.Net.Data.Models.Fields;

namespace QuickBooks.Net.Data.Models
{
    public class Class : QuickBooksBaseModel
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

        internal override QuickBooksBaseModel CreateReturnObject()
        {
            return new Class
            {
                Name = Name,
                SubClass = SubClass,
                ParentRef = ParentRef,
                FullyQualifiedName = FullyQualifiedName,
                Active = Active
            };
        }

        internal override QuickBooksBaseModel UpdateReturnObject()
        {
            return this;
        }

        internal override QuickBooksBaseModel DeleteReturnObject()
        {
            return new Class
            {
                Id = Id,
                SyncToken = SyncToken,
                Active = false
            };
        }
    }
}