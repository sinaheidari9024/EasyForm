using EasyForm.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Stores.Contracts
{
    public interface IAnswerStore
    {
        Task<bool> SetAnswersAsync(List<Answer> answers);
        Task DeleteAnswersAsync(int userApplicationId);
    }
}
