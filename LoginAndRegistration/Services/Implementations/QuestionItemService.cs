using AutoMapper;
using EasyForm.Entities;
using EasyForm.Services.Contracts;
using EasyForm.Stores.Contracts;
using EasyForm.Stores.Implementations;
using EasyForm.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Services.Implementations
{
    public class QuestionItemService : IQuestionItemService
    {
        private readonly IQuestionItemStore _questionItemStore;
        private readonly IMapper _mapper;


        public QuestionItemService(IQuestionItemStore questionItemStore, IMapper mapper)
        {
            _questionItemStore = questionItemStore;
            _mapper = mapper;
        }

        public async Task<bool> AddQuestionItemtAsync(QuestionItem item)
        {
            return await _questionItemStore.AddQuestionItemtAsync(item);
        }

        public async Task<bool> DeleteQuestionItemAsync(int id)
        {
            //todo  check answer
            return await _questionItemStore.DeleteQuestionItemAsync(id);
        }

        public async Task<QuestionItem> GetQuestionItemAsync(int id)
        {
            return await _questionItemStore.GetQuestionItemAsync(id);
        }

        public async Task<List<GetQuestionItemVm>> GetQuestionItemsAsync(int questionId)
        {
            var result = await _questionItemStore.GetQuestionItemsAsync(questionId);
            return _mapper.Map<List<GetQuestionItemVm>>(result);
        }

        public async Task<bool> UpdateQuestionItemAsync(QuestionItem items)
        {
            return await _questionItemStore.UpdateQuestionItemAsync(items);
        }

        public async Task<bool> ToggleActivationAsync(int itemId, bool currentStatus)
        {
            var item = await _questionItemStore.GetQuestionItemAsync(itemId);
            item.IsActive = !currentStatus;
            return await _questionItemStore.UpdateQuestionItemAsync(item);
        }
    }
}
