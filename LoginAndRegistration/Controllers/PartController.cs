using AutoMapper;
using EasyForm.Entities;
using EasyForm.Services.Contracts;
using EasyForm.Utils;
using EasyForm.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Controllers
{
    [Authorize(Policy = Constants.Admin)]
    public class PartController : Controller
    {
        private readonly ILogger<PartController> _logger;
        private readonly IPartService _partService;
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public PartController(ILogger<PartController> logger
                                , IPartService partService
                                , IApplicationService applicationSerive
                                , IMapper mapper)
        {
            _logger = logger;
            _partService = partService;
            _applicationService = applicationSerive;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index(int applicationId = 0)
        {
            GetApplicationPartVm response;
            if (applicationId == 0)
            {
                response = await _partService.GetApplicationPartsAsync();
            }
            else
            {
                response = await _partService.GetApplicationPartsAsync(applicationId);
            }

            return View(response);
        }


        [HttpGet]
        public async Task<IActionResult> Create(int applicationId)
        {
            ViewData["Action"] = Constants.CreateAction;
            List<SelectListItem> applications = new List<SelectListItem>();
            if (applicationId == 0)
            {
                var Applications = await _applicationService.GetApplicationsAsync(string.Empty);
                foreach (var app in Applications)
                {
                    applications.Add(
                        new SelectListItem
                        {
                            Text = app.Title,
                            Value = app.Id.ToString()
                        }
                    );
                }
            }
            var response = new CreateApplicationPartVm
            {
                ApplicationId = applicationId,
                Applications = applications
            };
            return View(Constants.CreateAction, response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateApplicationPartVm model)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> applications = new List<SelectListItem>();
                var Applications = await _applicationService.GetApplicationsAsync(string.Empty);
                foreach (var app in Applications)
                {
                    applications.Add(
                        new SelectListItem
                        {
                            Text = app.Title,
                            Value = app.Id.ToString()
                        }
                    );
                }
                model.Applications = applications;
                return View(Constants.CreateAction, model.ApplicationId);
            }
            var part = _mapper.Map<ApplicationPart>(model);

            TempData[Constants.IsShow] = "";
            var result = await _partService.AddApplicationPartAsync(part);
            if (result)
            {
                TempData[Constants.IsShow] = "Part updated successfully.";
            }
            else
            {
                TempData[Constants.IsShow] = "We have some problem in creating this part.";
                _logger.LogError($"{Constants.UserError}: \"We have some problem in creating this part.");

            }
            return RedirectToAction(Constants.IndexAction, model.ApplicationId);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int partId)
        {
            ViewData["Action"] = Constants.EditAction;
            var application = await _partService.GetApplicationPartAsync(partId);
            List<SelectListItem> applications = new List<SelectListItem>();

            var response = _mapper.Map<CreateApplicationPartVm>(application);
            var Applications = await _applicationService.GetApplicationsAsync(string.Empty);
            foreach (var app in Applications)
            {
                applications.Add(
                    new SelectListItem
                    {
                        Text = app.Title,
                        Value = app.Id.ToString(),
                        Selected = app.Id == response.Id
                    }
                );
            }
            response.Applications = applications;
            return View(Constants.CreateAction, response);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(CreateApplicationPartVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(Constants.CreateAction, model);
            }
            var applicationPart = _mapper.Map<ApplicationPart>(model);
            TempData[Constants.IsShow] = "";
            var result = await _partService.UpdateApplicationPartAsync(applicationPart);
            if (result)
            {
                TempData[Constants.IsShow] = "Part updated successfully.";
            }
            else
            {
                TempData[Constants.IsShow] = "We have some problem in update this part.";
                _logger.LogError($"{Constants.UserError}: \"We have some problem in update this part.");
            }
            return RedirectToAction(Constants.IndexAction, model.ApplicationId);
        }

        public async Task<IActionResult> Delete(int partId)
        {
            TempData[Constants.IsShow] = "";
            var result = await _partService.DeleteApplicationPartAsync(partId);
            if (!result)
            {
                TempData[Constants.IsShow] = $"{Constants.UserError} : This Part has Question and You can not delete it";
                _logger.LogError($"{Constants.UserError}: This Part has Question and You can not delete it");
            }
            var response = await _partService.GetApplicationPartsAsync();
            return RedirectToAction(Constants.IndexAction, response);
        }

    }
}
