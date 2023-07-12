using EasyForm.Entities;
using EasyForm.Services.Contracts;
using EasyForm.Stores.Contracts;
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
            return await _applicationStore.AddApplication(application);
        }
    }
}
