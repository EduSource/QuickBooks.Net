using System;
using QuickBooks.Net.Data.Error_Responses;

namespace QuickBooks.Net.Exceptions
{
    public class QuickBooksException : Exception
    {
        public QuickBooksErrorResponse Response;

        public QuickBooksException(string message, string detail) : base(message)
        {
            Response = new QuickBooksErrorResponse
            {
                Fault = new FaultResponse()
            };

            Response.Fault.AddError(message, detail);
        }

        public QuickBooksException(string message, string detail, string errorCode) : base(message)
        {
            Response = new QuickBooksErrorResponse
            {
                Fault = new FaultResponse()
            };

            Response.Fault.AddError(message, detail, errorCode);
        }

        public QuickBooksException(string message, QuickBooksErrorResponse response) : base(message)
        {
            Response = response;
        }

    }
}
