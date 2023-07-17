using EasyForm.Entities;
using EasyForm.Services.Contracts;
using EasyForm.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EasyForm.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationService _applicationService;

        public ApplicationController(ILogger<HomeController> logger
                                , IApplicationService applicationService)
        {
            _logger = logger;
            _applicationService = applicationService;
        }

        public async Task<IActionResult> Index(string name)
        {
            var response = await _applicationService.GetApplicationsAsync(name);
            return View(response);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Action"] = Constants.CreateAction;
            var application = new Application();
            return View(Constants.CreateAction, application);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Application application)
        {
            await _applicationService.AddApplication(application);
            var response = await _applicationService.GetApplicationsAsync(string.Empty);
            return View(Constants.IndexAction, response);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int applicationId)
        {
            ViewData["Action"] = Constants.EditAction;
            var application = await _applicationService.GetApplicationAsync(applicationId);
            return View(Constants.CreateAction, application);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Application application)
        {
            await _applicationService.UpdateApplicationAsync(application);
            var response = await _applicationService.GetApplicationsAsync(string.Empty);
            return View(Constants.IndexAction, response);
        }

        public async Task<IActionResult> Delete(int applicationId)
        {
            await _applicationService.DeleteApplicationAsync(applicationId);
            var response = await _applicationService.GetApplicationsAsync(string.Empty);
            return View(Constants.IndexAction, response);
        }

    }
}
