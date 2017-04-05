namespace QuickBooks.Net.Data.Models.Fields
{
    public class EmailAddress
    {
        public string Address { get; set; }

        public override string ToString()
        {
            return Address;
        }
    }
}