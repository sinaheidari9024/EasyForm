using EasyForm.Entities;
using EasyForm.Models;
using EasyForm.Stores.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Stores.Implementations
{
    public class AnswerStore : IAnswerStore
    {
        private readonly ApplicationDbContext _context;

        public AnswerStore(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SetAnswersAsync(List<Answer> answers)
        {
            await _context.Answers.AddRangeAsync(answers);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task DeleteAnswersAsync(int userApplicationId)
        {
            var answers = await _context.Answers.Where(s=>s.UserApplicationId == userApplicationId).ToListAsync();
             _context.Answers.RemoveRange(answers);
        }

    }
}
