using EasyForm.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Services.Contracts
{
    public interface IApplicationService
    {
        Task<bool> AddApplication(Application application);
        Task<bool> UpdateApplicationAsync(Application application);
        Task<bool> DeleteApplicationAsync(int id);
        Task<Application> GetApplicationAsync(int id);
        Task<List<Application>> GetApplicationsAsync(string name);
    }
}
