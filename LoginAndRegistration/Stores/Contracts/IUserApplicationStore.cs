using EasyForm.Entities;
using EasyForm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Stores.Contracts
{
    public interface IUserApplicationStore
    {
        Task<List<GetUserApplicationViewModel>> GetUserApplicationsAsync(int userId);
        Task<UserApplication> GetUserApplicationAsync(int id);
        Task<UserApplication> GetUserApplicationIncludePartsAsync(int id);
        Task<bool> DeleteUserApplicationAsync(UserApplication item);
        Task<int> CreateNewUserApplicationAsync(UserApplication item);
        Task<List<GetUserApplicationViewModel>> GetUserApplicationsAsync(int take, int skip, string email = null);
        Task<int> GetUserApplicationsCountAsync(string email = null);
    }
}
