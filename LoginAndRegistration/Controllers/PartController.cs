﻿using AutoMapper;
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
    [Authorize]
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
        public async Task<IActionResult> CreateAsync(ApplicationPart part)
        {
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
            var response = await _partService.GetApplicationPartsAsync();
            return RedirectToAction(Constants.IndexAction, response);
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
        public async Task<IActionResult> EditAsync(ApplicationPart applicationPart)
        {
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
            var response = await _partService.GetApplicationPartsAsync();
            return RedirectToAction(Constants.IndexAction, response);
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