using EasyForm.Entities;
using EasyForm.Models;
using EasyForm.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Services.Contracts
{
    public interface IUserApplicationService
    {
        Task<List<UserApplicationViewModel>> GetUserApplicationsAsync(int userId);
        Task<UserApplication> GetUserApplicationAsync(int id);
        Task<ApplicationPartsVm> GetUserApplicationIncludePartsAsync(int id);
        Task<bool> DeleteUserApplicationAsync(UserApplication item);
    }
}
