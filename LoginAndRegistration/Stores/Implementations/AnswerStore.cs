using EasyForm.Models;

namespace EasyForm.Stores.Implementations
{
    public class AnswerStore
    {
        private readonly ApplicationDbContext _context;

        public AnswerStore(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
