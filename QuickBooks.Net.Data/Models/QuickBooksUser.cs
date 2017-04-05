namespace QuickBooks.Net.Data.Models
{
    public class QuickBooksUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ScreenName { get; set; }
        public bool IsVerified { get; set; }
    }
}
