namespace QuickBooks.Net.Exceptions
{
    public class QuickBooksTimeoutException : QuickBooksException
    {

        public QuickBooksTimeoutException(string message, string detail) 
            : base (message, detail)
        {
        }
    }
}
