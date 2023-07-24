using EasyForm.Entities;
using EasyForm.Models;
using EasyForm.Services.Contracts;
using EasyForm.Stores.Contracts;
using EasyForm.Utils;
using EasyForm.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

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

        public async Task<List<GetUserApplicationViewModel>> GetUserApplicationsAsync(int userId)
        {
            return await _userApplicationStore.GetUserApplicationsAsync(userId);
        }

        public async Task<UserApplicationWithPaginationVm> GetUserApplicationsAsync(DataGridSearch dataGridSearch)
        {
            var skip = (dataGridSearch.PageNumber - 1) * Constants.PageItems;
            var result = await _userApplicationStore.GetUserApplicationsAsync(Constants.PageItems
                                                                                , skip
                                                                                , dataGridSearch.Email);
            dataGridSearch.PageCount = Convert.ToInt32(Math.Ceiling((await _userApplicationStore.GetUserApplicationsCountAsync(dataGridSearch.Email))
                / (decimal)Constants.PageItems));
            
            var response = new UserApplicationWithPaginationVm
            {
                dataGridSearch = dataGridSearch
            };

            if (dataGridSearch.SortDir == "Asc")
            {
                result = result.OrderBy(p => "p." + dataGridSearch.SortBy).ToList();
            }
            else
            {
                result  = result.OrderByDescending(p => EF.Property<IPagedList<GetUserApplicationViewModel>>(p, dataGridSearch.SortBy)).ToList();
            }
            response.UserApplication = result.ToPagedList(dataGridSearch.PageNumber, Constants.PageItems);
            return response;
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
                    Questions = await _questionService.GetQuestionIncludeItemsAndAnswerAsync(result.Id)
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
