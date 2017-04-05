using System;

namespace QuickBooks.Net.Exceptions
{
    public class UnauthorizedQuickBooksClientException : Exception
    {
        public UnauthorizedQuickBooksClientException()
        {
        }

        public UnauthorizedQuickBooksClientException(string message)
            : base(message)
        {
        }

        public UnauthorizedQuickBooksClientException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}