using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickBooks.Net.Data.Models;
using QuickBooks.Net.Data.Models.Batch;

namespace QuickBooks.Net.Controllers
{
    public class ClassController : BaseController, IClassController
    {
        protected override string ObjectName => "Class";

        public ClassController(QuickBooksClient client, string oAuthVersion) : base(client, oAuthVersion)
        {
        }

        public async Task<Class> GetClassAsync(string classId)
        {
            return await GetRequestString<Class>(classId);
        }

        public async Task<IEnumerable<Class>> GetClassesAsync(bool activeAndInactive = false, bool onlyInactive = false, int startPosition = 1, int maxResults = 100)
        {
            if (activeAndInactive && onlyInactive)
                throw new ArgumentException($"{nameof(activeAndInactive)} and {nameof(onlyInactive)} cannot be both set to true");

            var query = $"Select * From {ObjectName}";

            if (activeAndInactive)
            {
                query += " Where Active IN (True, False)";
            }
            else if (onlyInactive)
            {
                query += " Where Active = False";
            }

            return await QueryRequestString<Class>(query, startPosition, maxResults);
        }

        public async Task<IEnumerable<Class>> QueryClassesAsync(string query)
        {
            return await QueryRequestString<Class>(query, overrideOptions: true);
        }

        public async Task<int> GetClassCountAsync()
        {
            return await GetObjectCount<Class>();
        }

        public async Task<Class> CreateClassAsync(Class classModel)
        {
            return await PostRequestString(classModel.CreateReturnObject() as Class);
        }

        public async Task<IBatchResponse<Class>> CreateClassesAsync(IEnumerable<Class> classModels)
        {
            return await BatchRequestString<Class>(classModels, BatchOperation.Create);
        }

        public async Task<IBatchResponse<Class>> CreateClassesAsync(params Class[] classModels)
        {
            return await CreateClassesAsync(classModels.AsEnumerable());
        }

        public async Task<Class> UpdateClassAsync(Class classModel)
        {
            return await PostRequestString(classModel.UpdateReturnObject() as Class, true);
        }

        public async Task<IBatchResponse<Class>> UpdateClassesAsync(IEnumerable<Class> classModels)
        {
            return await BatchRequestString<Class>(classModels, BatchOperation.Update);
        }

        public async Task<IBatchResponse<Class>> UpdateClassesAsync(params Class[] classModels)
        {
            return await UpdateClassesAsync(classModels.AsEnumerable());
        }

        public async Task<Class> DeactiveClassAsync(Class classModel)
        {
            return await PostRequestString(classModel.DeleteReturnObject() as Class, true);
        }

        public async Task<Class> DeactiveClassAsync(string classId, int syncToken)
        {
            return await DeactiveClassAsync(new Class
            {
                Id = classId,
                SyncToken = syncToken
            });
        }

        public async Task<IBatchResponse<Class>> DeactivateClassesAsync(IEnumerable<Class> classModels)
        {
            return await BatchRequestString<Class>(classModels.Select(x => x.DeleteReturnObject() as Class), BatchOperation.Update);
        }

        public async Task<IBatchResponse<Class>> DeactivateClassesAsync(params Class[] classModels)
        {
            return await DeactivateClassesAsync(classModels.AsEnumerable());
        }
    }
}