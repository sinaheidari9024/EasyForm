using DocumentFormat.OpenXml.Spreadsheet;
using EasyForm.Entities;
using EasyForm.Models;
using EasyForm.Services.Contracts;
using EasyForm.Utils;
using EasyForm.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserApplicationService _userApplicationService;
        private readonly IQuestionService _questionService;
        private readonly UserManager<User> _userManager;
        private readonly IAnswerService _answerService;

        public HomeController(ILogger<HomeController> logger
                                , IUserApplicationService userApplicationService
                                , UserManager<User> userManager
                                , IQuestionService questionService
                                , IAnswerService answerService)
        {
            _logger = logger;
            _userApplicationService = userApplicationService;
            _userManager = userManager;
            _questionService = questionService;
            _answerService = answerService;
        }

        public async Task<IActionResult> Index()
        {
            int userId = Convert.ToInt32(_userManager.GetUserId(User));
            var userApplications = await _userApplicationService.GetUserApplicationsAsync(userId);
            return View(userApplications);
        }

        public async Task<IActionResult> Edit(int userApplicationId)
        {
            var result = await _userApplicationService.GetUserApplicationIncludePartsAsync(userApplicationId);
            var Questions = await _questionService.GetQuestionIncludeItemsAndAnswerAsync(userApplicationId);

            foreach (var part in result.Parts)
            {
                part.Questions = Questions.Where(s=>s.ApplicationPartId == userApplicationId).ToList();
                part.IsCompleted = !Questions.Any(s=>s.ApplicationPartId==userApplicationId 
                                                    && s.IsRequierd  
                                                    && string.IsNullOrEmpty(s.Answer));
                                                }

            return View(result);
        }

        public async Task<IActionResult> CreateNew()
        {
            int userId = Convert.ToInt32(_userManager.GetUserId(User));
            var newItemId =  await _userApplicationService.CreateNewUserApplication(userId);
            var result = await _userApplicationService.GetUserApplicationIncludePartsAsync(newItemId);
            var Questions = await _questionService.GetQuestionIncludeItemsAndAnswerAsync(newItemId);

            foreach (var part in result.Parts)
            {
                part.Questions = Questions.Where(s => s.ApplicationPartId == newItemId).ToList();
            }
            return View("Edit", result);
        }

        public async Task<IActionResult> Delete(int userApplicationId)
        {
            var userApplication = await _userApplicationService.GetUserApplicationAsync(userApplicationId);
            if (userApplication != null)
            {
                await _userApplicationService.DeleteUserApplicationAsync(userApplication);
            }

            int userId = Convert.ToInt32(_userManager.GetUserId(User));
            var userApplications = await _userApplicationService.GetUserApplicationsAsync(userId);

            return View("Index", userApplications);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ActionName("AnswerAsync")]
        public async Task<IActionResult> AnswerAsync([FromBody]List<AnswerVm> answers)
        {
            var response = await _answerService.SetAnswersAsync(answers);
            if (response)
            {
                TempData[Constants.IsShow] = "Updated successfully.";
            }
            else
            {
                TempData[Constants.IsShow] = "We have some problem in saving the answers.";
                _logger.LogError($"{Constants.UserError}: \"We have some problem in saving the answers.");
                var userApplicationId = answers.FirstOrDefault().UserApplicationId;
                var result = await _userApplicationService.GetUserApplicationIncludePartsAsync(userApplicationId);
                var Questions = await _questionService.GetQuestionIncludeItemsAndAnswerAsync(userApplicationId);

                foreach (var part in result.Parts)
                {
                    part.Questions = Questions.Where(s => s.ApplicationPartId == userApplicationId).ToList();
                    part.IsCompleted = !Questions.Any(s => s.ApplicationPartId == userApplicationId
                                                        && s.IsRequierd
                                                        && string.IsNullOrEmpty(s.Answer));
                }

                return View("Edit", result);
            }

            return View("Index");
        }
    }
}
