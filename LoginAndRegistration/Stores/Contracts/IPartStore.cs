using EasyForm.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Stores.Contracts
{
    public interface IPartStore
    {
        Task<bool> AddApplicationPartAsync(ApplicationPart application);
        Task<bool> UpdateApplicationPartAsync(ApplicationPart application);
        Task<bool> DeleteApplicationPartAsync(int id);
        Task<ApplicationPart> GetApplicationPartAsync(int id);
        Task<List<ApplicationPart>> GetApplicationPartsAsync(int applicationId);
        Task<List<ApplicationPart>> GetApplicationPartsAsync();
    }
}
