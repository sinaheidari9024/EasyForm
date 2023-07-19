using EasyForm.Entities;
using EasyForm.Models;
using EasyForm.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Services.Contracts
{
    public interface IUserApplicationService
    {
        Task<List<GetUserApplicationViewModel>> GetUserApplicationsAsync(int userId);
        Task<UserApplicationWithPaginationVm> GetUserApplicationsAsync(DataGridSearch dataGridSearch);
        Task<UserApplication> GetUserApplicationAsync(int id);
        Task<ApplicationPartsVm> GetUserApplicationIncludePartsAsync(int id);
        Task<bool> DeleteUserApplicationAsync(UserApplication item);
        Task<int> CreateNewUserApplication(int UserId);
    }
}
