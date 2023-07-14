﻿using EasyForm.Enum;
using EasyForm.Models;
using EasyForm.Services.Contracts;
using EasyForm.Stores.Contracts;
using EasyForm.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionStore _questionStore;

        public QuestionService(IQuestionStore questionStore)
        {
            _questionStore = questionStore;
        }

        public async Task<List<QuestionComplexModel>> GetQuestionIncludeItemsAndAnswerAsync(int partId, int UserApplicationId)
        {
            var result = await _questionStore.GetQuestionIncludeItemsAndAnswerAsync(partId, UserApplicationId);
            var model = new List<QuestionComplexModel>();

            foreach (var item in result)
            {
                var answer = item.Answer.FirstOrDefault();
                var questionItems = new List<QuestionItemVm>();

                if (answer != null)
                {
                    if (item.Type == QuestionType.DropDown || item.Type == QuestionType.CheckBox || item.Type == QuestionType.OptionBox)
                    {
                        foreach (var questionItem in item.QuestionItems)
                        {
                            List<int> intTest = item.Text.Split(',').Select(int.Parse).ToList();
                            var isChecked = intTest.Contains(questionItem.Id);
                            questionItems.Add(new QuestionItemVm
                            {
                                Id = questionItem.Id,
                                Title = questionItem.Title,
                                IsChecked = isChecked
                            });
                        }
                    }
                }
                model.Add(new QuestionComplexModel
                {
                    Answer = answer?.Text,
                    Text = item.Text,
                    Type = item.Type,
                    Number = item.Number,
                    QuestionId = item.Id,
                    Items = questionItems,
                    Table1 = answer != null && item.Type == QuestionType.Table1 ? Newtonsoft.Json.JsonConvert.DeserializeObject<Table1>(answer.Text) : null,
                    Table2 = answer != null && item.Type == QuestionType.Table2 ? Newtonsoft.Json.JsonConvert.DeserializeObject<Table2>(answer.Text) : null
                });

            }
            return model;


        }
    }
}