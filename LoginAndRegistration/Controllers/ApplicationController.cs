using AutoMapper;
using EasyForm.Entities;
using EasyForm.Services.Contracts;
using EasyForm.Utils;
using EasyForm.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EasyForm.Controllers
{
    [Authorize(Policy = Constants.Admin)]
    public class ApplicationController : Controller
    {
        private readonly ILogger<ApplicationController> _logger;
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public ApplicationController(ILogger<ApplicationController> logger
                                , IApplicationService applicationService
                                , IMapper mapper)
        {
            _logger = logger;
            _applicationService = applicationService;
            _mapper = mapper;
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
            var application = new ApplicationVm();
            return View(Constants.CreateAction, application);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ApplicationVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(Constants.CreateAction, model);
            }
            var application = _mapper.Map<Application>(model);

            var result = await _applicationService.AddApplication(application);
            if (result)
            {
                TempData[Constants.IsShow] = "Part updated successfully.";
            }
            else
            {
                TempData[Constants.IsShow] = "We have some problem in creating this part.";
                _logger.LogError($"{Constants.UserError}: \"We have some problem in creating this part.");
            }

            var response = await _applicationService.GetApplicationsAsync(string.Empty);
            return RedirectToAction(Constants.IndexAction, response);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int applicationId)
        {
            ViewData["Action"] = Constants.EditAction;
            var application = await _applicationService.GetApplicationAsync(applicationId);
            var model = _mapper.Map<ApplicationVm>(application);
            return View(Constants.CreateAction, model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(ApplicationVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(Constants.CreateAction, model);
            }
            var application = _mapper.Map<Application>(model);
            var result = await _applicationService.UpdateApplicationAsync(application);

            if (result)
            {
                TempData[Constants.IsShow] = "Part updated successfully.";
            }
            else
            {
                TempData[Constants.IsShow] = "We have some problem in creating this part.";
                _logger.LogError($"{Constants.UserError}: \"We have some problem in creating this part.");
            }

            var response = await _applicationService.GetApplicationsAsync(string.Empty);
            return RedirectToAction(Constants.IndexAction, response);
        }

        public async Task<IActionResult> Delete(int applicationId)
        {
            await _applicationService.DeleteApplicationAsync(applicationId);
            var response = await _applicationService.GetApplicationsAsync(string.Empty);
            return RedirectToAction(Constants.IndexAction, response);
        }

    }
}
