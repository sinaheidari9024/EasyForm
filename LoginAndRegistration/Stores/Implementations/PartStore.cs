using EasyForm.Entities;
using EasyForm.Models;
using EasyForm.Stores.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Stores.Implementations
{
    public class PartStore : IPartStore
    {
        private readonly ApplicationDbContext _context;

        public PartStore(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddApplicationPartAsync(ApplicationPart applicationPart)
        {
            await _context.ApplicationParts.AddAsync(applicationPart);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteApplicationPartAsync(int id)
        {
            var part = await _context.ApplicationParts.FirstOrDefaultAsync(s => s.Id == id);
            if (part != null)
            {
                _context.ApplicationParts.Remove(part);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<ApplicationPart> GetApplicationPartAsync(int id)
        {
            return await _context.ApplicationParts.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<ApplicationPart>> GetApplicationPartsAsync(int applicationId)
        {
            return await _context.ApplicationParts
                                            .Include(s => s.Application)
                                            .Where(s => s.ApplicationId == applicationId)
                                            .ToListAsync();
        }

        public async Task<List<ApplicationPart>> GetApplicationPartsAsync()
        {
            return await _context.ApplicationParts.Include(s=>s.Application).ToListAsync();
        }

        public async Task<bool> UpdateApplicationPartAsync(ApplicationPart applicationPart)
        {
            _context.ApplicationParts.Update(applicationPart);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
