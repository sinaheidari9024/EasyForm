using EasyForm.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Stores.Contracts
{
    public interface IApplicationStore
    {
        Task<bool> AddApplication(Application application);
        Task<Application> UpdateApplication(Application application, int id);
        Task<bool> DeleteApplication(int id);
        Task<Application> GetApplication(int id);
        Task<List<Application>> GetApplications(string name);
    }
}
