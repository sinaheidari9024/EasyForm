using EasyForm.Entities;
using EasyForm.Models;
using EasyForm.Services.Contracts;
using EasyForm.Stores.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Services.Implementations
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserApplicationStore _userApplicationStore;

        public UserApplicationService(IUserApplicationStore userApplicationStore)
        {
            _userApplicationStore = userApplicationStore;
        }

        public async Task<List<UserApplicationViewModel>> GetUserApplicationsAsync(int userId)
        {
            return await _userApplicationStore.GetUserApplicationsAsync(userId);
        }

        public async Task<UserApplication> GetUserApplicationAsync(int userId)
        {
            return await _userApplicationStore.GetUserApplicationAsync(userId);
        }

        public async Task<bool> DeleteUserApplicationAsync(UserApplication item)
        {
            return await _userApplicationStore.DeleteUserApplicationAsync(item);
        }
    }
}
