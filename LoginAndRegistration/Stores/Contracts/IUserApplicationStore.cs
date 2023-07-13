using EasyForm.Entities;
using EasyForm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Stores.Contracts
{
    public interface IUserApplicationStore
    {
        Task<List<UserApplicationViewModel>> GetUserApplicationsAsync(int userId);
        Task<UserApplication> GetUserApplicationAsync(int id);
        Task<UserApplication> GetUserApplicationIncludePartsAsync(int id);
        Task<bool> DeleteUserApplicationAsync(UserApplication item);
    }
}
