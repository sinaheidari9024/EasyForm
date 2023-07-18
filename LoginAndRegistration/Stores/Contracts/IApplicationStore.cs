using EasyForm.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Stores.Contracts
{
    public interface IApplicationStore
    {
        Task<bool> AddApplicationAsync(Application application);
        Task<bool> UpdateApplicationAsync(Application application);
        Task<bool> DeleteApplicationAsync(int id);
        Task<Application> GetApplicationAsync(int id);
        Task<List<Application>> GetApplicationsAsync(string name);
    }
}
