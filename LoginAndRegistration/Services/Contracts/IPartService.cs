using EasyForm.Entities;
using EasyForm.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Services.Contracts
{
    public interface IPartService
    {
        Task<bool> AddApplicationPartAsync(ApplicationPart applicationPart);
        Task<bool> UpdateApplicationPartAsync(ApplicationPart applicationPart);
        Task<bool> DeleteApplicationPartAsync(int id);
        Task<ApplicationPart> GetApplicationPartAsync(int id);
        Task<GetApplicationPartVm> GetApplicationPartsAsync(int applicationId);
        Task<GetApplicationPartVm> GetApplicationPartsAsync();
        Task<List<ApplicationPart>> GetPartListAsync();
    }
}
