namespace QuickBooks.Net.Exceptions
{
    public class QuickbooksAuthorizationException : QuickBooksException
    {
        public QuickbooksAuthorizationException(string message, string detail, string errorCode)
            : base(message, detail, errorCode)
        {
        }
    }
}