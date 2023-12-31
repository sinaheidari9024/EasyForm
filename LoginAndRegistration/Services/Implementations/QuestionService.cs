﻿using AutoMapper;
using EasyForm.Entities;
using EasyForm.Enum;
using EasyForm.Models;
using EasyForm.Services.Contracts;
using EasyForm.Stores.Contracts;
using EasyForm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionStore _questionStore;

        public QuestionService(IQuestionStore questionStore, IMapper mapper)
        {
            _questionStore = questionStore;
            _mapper = mapper;
        }

        public async Task<bool> AddQuestionAsync(Question question)
        {
            question.IsActive = true;
            return await _questionStore.AddQuestionAsync(question);
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            return await _questionStore.DeleteQuestionAsync(id);
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            return await _questionStore.GetQuestionAsync(id);
        }

        public async Task<Question> GetQuestionIncludeItemsAsync(int id)
        {
            return await _questionStore.GetQuestionIncludeItemsAsync(id);
        }

        public async Task<List<QuestionComplexModel>> GetQuestionIncludeItemsAndAnswerAsync(int UserApplicationId)
        {
            var result = await _questionStore.GetQuestionIncludeItemsAndAnswerAsync(UserApplicationId);
            var model = new List<QuestionComplexModel>();

            foreach (var item in result)
            {
                var answer = item.Answers.FirstOrDefault();
                var questionItems = new List<QuestionItemVm>();


                    if (item.Type == QuestionType.DropDown || item.Type == QuestionType.CheckBox || item.Type == QuestionType.OptionBox || item.Type == QuestionType.CheckBoxTextBox)
                    {
                        foreach (var questionItem in item.QuestionItems)
                        {
                        List<int> intTest = new List<int>();
                        var test = answer?.Text?.Split(',');
                        if(test!= null)
                        {

                        foreach(var item2 in test)
                        {
                            if (int.TryParse(item2, out int value))
                            {
                                intTest.Add(Convert.ToInt32(item2));
                            }
                        }
                        }
                            var isChecked = intTest != null && intTest.Contains(questionItem.Id);
                            questionItems.Add(new QuestionItemVm
                            {
                                Id = questionItem.Id,
                                Title = questionItem.Title,
                                IsChecked = isChecked
                            });
                        }
                    }
                
                model.Add(new QuestionComplexModel
                {
                    Answer = answer?.Text,
                    ApplicationPartId = item.ApplicationPartId,
                    Text = item.Text,
                    SpanishText = item.SpanishText,
                    IsRequierd = item.IsRequierd,
                    Type = item.Type,
                    Number = item.Number,
                    QuestionId = item.Id,
                    Items = questionItems,
                    MaxLengh = item.MaxLengh,
                    Minlengh = item.Minlengh,
                    Table1 = answer != null && item.Type == QuestionType.Table1 ? Newtonsoft.Json.JsonConvert.DeserializeObject<List<Table1>>(answer.Text) : null,
                    Table2 = answer != null && item.Type == QuestionType.Table2 ? Newtonsoft.Json.JsonConvert.DeserializeObject<List<Table2>>(answer.Text) : null
                });

            }
            return model;


        }

        public async Task<GetQuestionVm> GetQuestionsAsync(int partId)
        {
            var response = await _questionStore.GetQuestionsAsync(partId);
            var questions = _mapper.Map<List<QuestionVm>>(response);
            return new GetQuestionVm { PartId = partId, Questions = questions.OrderBy(s=>s.PartId).ThenBy(s=>s.Priority).ToList() };
        }

        public async Task<GetQuestionVm> GetQuestionsAsync()
        {
            var response = await _questionStore.GetQuestionsAsync();
            var questions = _mapper.Map<List<QuestionVm>>(response);
            return new GetQuestionVm { PartId = 0, Questions = questions.OrderBy(s => s.PartId).ThenBy(s => s.Priority).ToList() };
        }

        public async Task<bool> ToggleActivationAsync(int questionId, bool currentStatus)
        {
            var question = await _questionStore.GetQuestionAsync(questionId);
            question.IsActive = !currentStatus;
            return await _questionStore.UpdateQuestionAsync(question);
        }

        public async Task<bool> UpdateQuestionAsync(Question question)
        {
            return await _questionStore.UpdateQuestionAsync(question);
        }
    }
}
