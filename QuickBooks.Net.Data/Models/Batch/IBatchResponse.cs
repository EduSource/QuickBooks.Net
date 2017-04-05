using System.Collections.Generic;
using QuickBooks.Net.Data.Error_Responses;

namespace QuickBooks.Net.Data.Models.Batch
{
    public interface IBatchResponse<T>
    {
        IEnumerable<QuickBooksErrorResponse> Errors { get; }
        IEnumerable<T> Data { get; }
    }
}
