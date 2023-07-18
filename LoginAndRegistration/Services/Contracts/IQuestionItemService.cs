using EasyForm.Entities;
using EasyForm.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Services.Contracts
{
    public interface IQuestionItemService
    {
        Task<bool> AddQuestionItemtAsync(QuestionItem item);
        Task<bool> UpdateQuestionItemAsync(QuestionItem items);
        Task<bool> DeleteQuestionItemAsync(int id);
        Task<QuestionItem> GetQuestionItemAsync(int id);
        Task<List<GetQuestionItemVm>> GetQuestionItemsAsync(int questionId);
    }
}
