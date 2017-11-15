using System.Collections.Generic;
using System.Threading.Tasks;
using QuickBooks.Net.Data.Models;
using QuickBooks.Net.Data.Models.Batch;

namespace QuickBooks.Net.Controllers
{
    public interface IClassController
    {
        Task<Class> GetClassAsync(int classId);

        Task<IEnumerable<Class>> GetClassesAsync(bool activeAndInactive = false, bool onlyInactive = false,
            int startPosition = 1, int maxResults = 100);

        Task<IEnumerable<Class>> QueryClassesAsync(string query);

        Task<int> GetClassCountAsync();

        Task<Class> CreateClassAsync(Class classModel);

        Task<IBatchResponse<Class>> CreateClassesAsync(IEnumerable<Class> classModels);

        Task<IBatchResponse<Class>> CreateClassesAsync(params Class[] classModels);

        Task<Class> UpdateClassAsync(Class classModel);

        Task<IBatchResponse<Class>> UpdateClassesAsync(IEnumerable<Class> classModels);

        Task<IBatchResponse<Class>> UpdateClassesAsync(params Class[] classModels);

        Task<Class> DeactiveClassAsync(Class classModel);

        Task<Class> DeactiveClassAsync(int classId, int syncToken);

        Task<IBatchResponse<Class>> DeactivateClassesAsync(IEnumerable<Class> classModels);

        Task<IBatchResponse<Class>> DeactivateClassesAsync(params Class[] classModels);
    }
}
