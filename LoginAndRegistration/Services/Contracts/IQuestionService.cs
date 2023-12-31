﻿using EasyForm.Entities;
using EasyForm.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Services.Contracts
{
    public interface IQuestionService
    {
        Task<List<QuestionComplexModel>> GetQuestionIncludeItemsAndAnswerAsync(int UserApplicationId);
        Task<bool> AddQuestionAsync(Question question);
        Task<bool> UpdateQuestionAsync(Question question);
        Task<bool> DeleteQuestionAsync(int id);
        Task<Question> GetQuestionAsync(int id);
        Task<GetQuestionVm> GetQuestionsAsync(int partId);
        Task<Question> GetQuestionIncludeItemsAsync(int id);
        Task<GetQuestionVm> GetQuestionsAsync();
        Task<bool> ToggleActivationAsync(int questionId, bool currentStatus);
    }
}
