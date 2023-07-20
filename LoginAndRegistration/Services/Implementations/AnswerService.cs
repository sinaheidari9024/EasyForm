using AutoMapper;
using EasyForm.Entities;
using EasyForm.Services.Contracts;
using EasyForm.Stores.Contracts;
using EasyForm.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Services.Implementations
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerStore _answerStore;
        private readonly IMapper _mapper;

        public AnswerService(IAnswerStore answerStore, IMapper mapper)
        {
            _answerStore = answerStore;
            _mapper = mapper;
        }

        public async Task<bool> SetAnswersAsync(List<AnswerVm> answersVm)
        {
            var answers = _mapper.Map<List<Answer>>(answersVm);
            await _answerStore.DeleteAnswersAsync(answers.FirstOrDefault().UserApplicationId);
            return await _answerStore.SetAnswersAsync(answers);
        }
    }
}
