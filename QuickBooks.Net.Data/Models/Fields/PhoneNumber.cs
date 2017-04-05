namespace QuickBooks.Net.Data.Models.Fields
{
    public class PhoneNumber
    {
        public string FreeFormNumber { get; set; }

        public override string ToString()
        {
            return FreeFormNumber;
        }
    }
}