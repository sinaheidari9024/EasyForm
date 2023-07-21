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

        public async Task<List<GetUserApplicationViewModel>> GetUserApplicationsAsync(int userId)
        {
            return await _context.UserApplications.Where(s => s.UserId == userId && !s.IsDeleted)
                .Select(s => new GetUserApplicationViewModel
                {
                    Id = s.Id,
                    Title = s.Application.Title,
                    SpanishTitle = s.Application.SpanishTitle,
                    CreationDate = s.CreatedDate
                }).ToListAsync();
        }

        public async Task<List<GetUserApplicationViewModel>> GetUserApplicationsAsync(int take
                                                                            , int skip
                                                                            , string email = null)
        {
            return await _context.UserApplications.Where(s => (s.User.Email.Contains(email) || email == null) && !s.IsDeleted)
                .Select(s => new GetUserApplicationViewModel
                {
                    Id = s.Id,
                    Title = s.Application.Title,
                    SpanishTitle = s.Application.SpanishTitle,
                    CreationDate = s.CreatedDate,
                    Email = s.User.Email,
                    IsCompleted = false //todo
                })
                .Skip(skip).Take(take).ToListAsync();
        }

        public async Task<int> GetUserApplicationsCountAsync(string email = null)
        {
            return await _context.UserApplications.Where(s => (s.User.Email == email || email == null) && !s.IsDeleted)
                .Select(s => new GetUserApplicationViewModel
                {
                    Id = s.Id,
                    Title = s.Application.Title,
                    SpanishTitle = s.Application.SpanishTitle,
                    CreationDate = s.CreatedDate,
                    Email = s.User.Email,
                    IsCompleted = false //todo
                }).CountAsync();
        }

        public async Task<UserApplication> GetUserApplicationAsync(int id)
        {
            return await _context.UserApplications.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<UserApplication> GetUserApplicationIncludePartsAsync(int id)
        {
            return await _context.UserApplications
                .Include(s => s.Application)
                .ThenInclude(s => s.ApplicationParts)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> DeleteUserApplicationAsync(UserApplication item)
        {
            _context.UserApplications.Remove(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> CreateNewUserApplicationAsync(UserApplication item)
        {
            await _context.UserApplications.AddAsync(item);
            await _context.SaveChangesAsync();

            return item.Id;
        }
    }
}
