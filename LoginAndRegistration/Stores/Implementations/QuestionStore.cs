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

        public async Task<bool> AddQuestionAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(s => s.Id == id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            return await _context.Questions.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Question> GetQuestionIncludeItemsAsync(int id)
        {
            return await _context.Questions.Include(s=>s.QuestionItems).Where(q => q.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Question>> GetQuestionIncludeItemsAndAnswerAsync(int partId, int UserApplicationId)
        {
            return await _context.Questions.Where(s => s.ApplicationPartId == partId && s.IsActive == true)
                .Include(s => s.Answers.Where(s=>s.UserApplicationId == UserApplicationId))
                .ToListAsync();
        }

        public async Task<List<Question>> GetQuestionsAsync(int partId)
        {
            return await _context.Questions
                                        .Where(s=>s.ApplicationPartId == partId)
                                        .Include(s=>s.Part)
                                        .ThenInclude(s=>s.Application)
                                        .ToListAsync();
        }

        public async Task<List<Question>> GetQuestionsAsync()
        {
            return await _context.Questions.Include(s => s.Part)
                                        .ThenInclude(s => s.Application).ToListAsync();

        }

        public async Task<bool> HasAnyQuestion(int partId)
        {
            return await _context.Questions.AnyAsync(s => s.ApplicationPartId == partId);
        }

        public async Task<bool> UpdateQuestionAsync(Question question)
        {
            _context.Questions.Update(question);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
