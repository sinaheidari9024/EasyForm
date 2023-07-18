using EasyForm.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Stores.Contracts
{
    public interface IQuestionItemStore
    {
        Task<bool> AddQuestionItemtAsync(QuestionItem item);
        Task<bool> UpdateQuestionItemAsync(QuestionItem items);
        Task<bool> DeleteQuestionItemAsync(int id);
        Task<QuestionItem> GetQuestionItemAsync(int id);
        Task<List<QuestionItem>> GetQuestionItemsAsync(int questionId);
    }
}
