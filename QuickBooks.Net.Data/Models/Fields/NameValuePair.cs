namespace QuickBooks.Net.Data.Models.Fields
{
    public class NameValuePair<TKey, TValue>
    {
        public TKey Name { get; set; }
        public TValue Value { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Value}";
        }
    }
}
