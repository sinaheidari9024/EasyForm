using EasyForm.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Services.Contracts
{
    public interface IQuestionService
    {
        Task<List<QuestionComplexModel>> GetQuestionIncludeItemsAndAnswerAsync(int partId, int UserApplicationId);
    }
}
