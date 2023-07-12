using EasyForm.Entities;
using EasyForm.Models;
using EasyForm.Stores.Contracts;
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


    }
}
