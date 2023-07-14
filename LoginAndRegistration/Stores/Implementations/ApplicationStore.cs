using EasyForm.Entities;
using EasyForm.Models;
using EasyForm.Stores.Contracts;
using System.Collections.Generic;
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

        public async Task<bool> AddApplication(Application application)
        {
            await _context.Applications.AddAsync(application);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> DeleteApplication(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Application> GetApplication(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Application>> GetApplications(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<Application> UpdateApplication(Application application, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
