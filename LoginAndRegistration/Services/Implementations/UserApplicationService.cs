using EasyForm.Entities;
using EasyForm.Models;
using EasyForm.Services.Contracts;
using EasyForm.Stores.Contracts;
using EasyForm.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Services.Implementations
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserApplicationStore _userApplicationStore;
        private readonly IQuestionService _questionService;

        public UserApplicationService(IUserApplicationStore userApplicationStore, IQuestionService questionService)
        {
            _userApplicationStore = userApplicationStore;
            _questionService = questionService;
        }

        public async Task<List<UserApplicationViewModel>> GetUserApplicationsAsync(int userId)
        {
            return await _userApplicationStore.GetUserApplicationsAsync(userId);
        }

        public async Task<UserApplication> GetUserApplicationAsync(int userId)
        {
            return await _userApplicationStore.GetUserApplicationAsync(userId);
        }

        public async Task<ApplicationPartsVm> GetUserApplicationIncludePartsAsync(int id)
        {
            var result = await _userApplicationStore.GetUserApplicationIncludePartsAsync(id);

            var model = new ApplicationPartsVm
            {
                CreationDate = result.CreatedDate,
                UserApplicationId = result.Id,
                Parts = new List<PartsVm>()

            };
            foreach (var part in result.Application.ApplicationParts)
            {
                model.Parts.Add(new PartsVm
                {
                    Description = part.Description,
                    Title = part.Title,
                    IsCompleted = false,
                    Questions = await _questionService.GetQuestionIncludeItemsAndAnswerAsync(1, result.Id)
                });
            }

            return model;

        }
        public async Task<bool> DeleteUserApplicationAsync(UserApplication item)
        {
            return await _userApplicationStore.DeleteUserApplicationAsync(item);
        }

        public async Task<int> CreateNewUserApplication(int userId)
        {
            var newItem = new UserApplication
            {
                ApplicationId = 1, //todo
                IsDeleted = false,
                UserId = userId,
                CreatedDate = DateTime.Now
            };

            return await _userApplicationStore.CreateNewUserApplicationAsync(newItem);
        }
    }
}
