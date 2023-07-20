using EasyForm.Entities;
using EasyForm.Models;
using EasyForm.Stores.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Stores.Implementations
{
    public class ApplicationStore : IApplicationStore
    {
        private readonly ApplicationDbContext _context;

        public ApplicationStore(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddApplicationAsync(Application application)
        {
            await _context.Applications.AddAsync(application);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteApplicationAsync(int id)
        {
            var application = await _context.Applications.FirstOrDefaultAsync(s => s.Id == id);
            if (application != null)
            {
                _context.Applications.Remove(application);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Application> GetApplicationAsync(int id)
        {
            return await _context.Applications.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Application>> GetApplicationsAsync(string name)
        {
            return await _context.Applications.Where(s => s.Title == name || string.IsNullOrEmpty(name)).ToListAsync();
        }

        public async Task<bool> UpdateApplicationAsync(Application application)
        {
            _context.Applications.Update(application);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
