using EasyForm.Entities;
using EasyForm.Models;
using EasyForm.Stores.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EasyForm.Stores.Implementations
{
    public class QuestionStore : IQuestionStore
    {
        private readonly ApplicationDbContext _context;

        public QuestionStore(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetQuestionIncludeItemsAndAnswerAsync(int partId, int UserApplicationId)
        {
            return await _context.Questions.Where(s => s.ApplicationPartId == partId )
                .Include(s => s.Answer.Where(s=>s.UserApplicationId == UserApplicationId))
                .Include(s => s.QuestionItems)
                .ThenInclude(s => s.EnableQuestion)
                .Include(s => s.QuestionItems)
                .ThenInclude(s => s.DisableQuestion)
                .ToListAsync();
        }

        public async Task<bool> HasAnyQuestion(int partId)
        {
            return await _context.Questions.AnyAsync(s => s.ApplicationPartId == partId);
        }
    }
}
