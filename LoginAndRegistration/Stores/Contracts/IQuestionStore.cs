using EasyForm.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Stores.Contracts
{
    public interface IQuestionStore
    {
        Task<List<Question>> GetQuestionIncludeItemsAndAnswerAsync(int partId, int UserApplicationId); 
    }
}
