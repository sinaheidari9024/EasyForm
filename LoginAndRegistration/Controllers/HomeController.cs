using EasyForm.Entities;
using EasyForm.Models;
using EasyForm.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
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

        public HomeController(ILogger<HomeController> logger
                                , IUserApplicationService userApplicationService
                                , UserManager<User> userManager
                                ,IQuestionService questionService)
        {
            _logger = logger;
            _userApplicationService = userApplicationService;
            _userManager = userManager;
            _questionService = questionService;
        }

        public async Task<IActionResult> Index()
        {
            var test = await _questionService.GetQuestionIncludeItemsAndAnswerAsync(1, 1);
            int userId = Convert.ToInt32(_userManager.GetUserId(User));
            var userApplications = await _userApplicationService.GetUserApplicationsAsync(userId);
            return View(userApplications);
        }

        public async Task<IActionResult> Edit(int userApplicationId)
        {
            var result = await _userApplicationService.GetUserApplicationIncludePartsAsync(userApplicationId);
            return View(result);
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
    }
}
