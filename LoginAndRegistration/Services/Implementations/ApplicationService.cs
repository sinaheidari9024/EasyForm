using EasyForm.Entities;
using EasyForm.Services.Contracts;
using EasyForm.Stores.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Services.Implementations
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationStore _applicationStore;

        public ApplicationService(IApplicationStore applicationStore)
        {
            _applicationStore = applicationStore;
        }

        public async Task<bool> AddApplication(Application application)
        {
            return await _applicationStore.AddApplicationAsync(application);
        }

        public async Task<bool> DeleteApplicationAsync(int id)
        {
           return await _applicationStore.DeleteApplicationAsync(id);
        }

        public async Task<Application> GetApplicationAsync(int id)
        {
            return await _applicationStore.GetApplicationAsync(id);
        }

        public async Task<List<Application>> GetApplicationsAsync(string name)
        {
            return await _applicationStore.GetApplicationsAsync(name);
        }

        public async Task<bool> UpdateApplicationAsync(Application application)
        {
            return await _applicationStore.UpdateApplicationAsync(application);
        }
    }
}
