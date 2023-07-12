using EasyForm.Entities;
using EasyForm.Models;
using EasyForm.Stores.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Stores.Implementations
{
    public class UserApplicationStore : IUserApplicationStore
    {
        private readonly ApplicationDbContext _context;

        public UserApplicationStore(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserApplicationViewModel>> GetUserApplicationsAsync(int userId)
        {
            return await _context.UserApplications.Where(s => s.UserId == userId && !s.IsDeleted)
                .Select(s => new UserApplicationViewModel
                {
                    Id = s.Id,
                    Title = s.Application.Title,
                    CreationDate = s.CreatedDate
                }).ToListAsync();
        }

        public async Task<UserApplication> GetUserApplicationAsync(int id)
        {
            return await _context.UserApplications.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> DeleteUserApplicationAsync(UserApplication item)
        {
            _context.UserApplications.Remove(item);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
