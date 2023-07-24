using EasyForm.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Services.Contracts
{
    public interface IAnswerService
    {
        Task<bool> SetAnswersAsync(List<AnswerVm> answers);
    }
}
