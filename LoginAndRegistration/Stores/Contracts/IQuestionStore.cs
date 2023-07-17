using EasyForm.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Stores.Contracts
{
    public interface IQuestionStore
    {
        Task<List<Question>> GetQuestionIncludeItemsAndAnswerAsync(int partId, int UserApplicationId);
        Task<bool> HasAnyQuestion(int partId);
        Task<bool> AddQuestionAsync(Question question);
        Task<bool> UpdateQuestionAsync(Question question);
        Task<bool> DeleteQuestionAsync(int id);
        Task<Question> GetQuestionAsync(int id);
        Task<List<Question>> GetQuestionsAsync(int questionId);
        Task<List<Question>> GetQuestionsAsync();

    }
}
