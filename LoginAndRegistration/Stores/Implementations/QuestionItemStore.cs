using EasyForm.Entities;
using EasyForm.Models;
using EasyForm.Stores.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Stores.Implementations
{
    public class QuestionItemStore : IQuestionItemStore
    {
        private readonly ApplicationDbContext _context;

        public QuestionItemStore(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddQuestionItemtAsync(QuestionItem item)
        {
            await _context.AddAsync(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteQuestionItemAsync(int id)
        {
            var item = await _context.QuestionItems.FirstOrDefaultAsync(s => s.Id == id);
            if (item != null)
            {
                _context.QuestionItems.Remove(item);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<QuestionItem> GetQuestionItemAsync(int id)
        {
            return await _context.QuestionItems.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<QuestionItem>> GetQuestionItemsAsync(int questionId)
        {
            return await _context.QuestionItems.Where(s => s.QuestionId == questionId).ToListAsync();
        }

        public async Task<bool> UpdateQuestionItemAsync(QuestionItem item)
        {
            _context.QuestionItems.Update(item);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
