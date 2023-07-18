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
    public class QuestionController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQuestionService _questionService;
        private readonly IPartService _partService;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionService questionService, ILogger<HomeController> logger, IPartService partService, IMapper mapper)
        {
            _questionService = questionService;
            _logger = logger;
            _partService = partService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int PartId = 0)
        {
            GetQuestionVm response;
            if (PartId == 0)
            {
                response = await _questionService.GetQuestionsAsync();
            }
            else
            {
                response = await _questionService.GetQuestionsAsync(PartId);
            }

            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int PartId)
        {
            ViewData["Action"] = Constants.CreateAction;
            List<SelectListItem> applicationPats = new List<SelectListItem>();
            if (PartId == 0)
            {
                var parts = await _partService.GetPartListAsync();
                foreach (var app in parts)
                {
                    applicationPats.Add(
                        new SelectListItem
                        {
                            Text = app.Title,
                            Value = app.Id.ToString()
                        }
                    );
                }
            }
            var response = new CreateQuestionVm
            {
                ApplicationPartId = PartId,
                Parts = applicationPats
            };
            return View(Constants.CreateAction, response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Question question)
        {
            TempData[Constants.IsShow] = "";
            var result = await _questionService.AddQuestionAsync(question);
            if (result)
            {
                TempData[Constants.IsShow] = "Part updated successfully.";
            }
            else
            {
                TempData[Constants.IsShow] = "We have some problem in creating this question.";
                _logger.LogError($"{Constants.UserError}: \"We have some problem in creating this question.");

            }
            var response = await _questionService.GetQuestionsAsync();
            return RedirectToAction(Constants.IndexAction, response);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int questionId)
        {
            ViewData["Action"] = Constants.EditAction;
            var application = await _questionService.GetQuestionAsync(questionId);
            List<SelectListItem> parts = new List<SelectListItem>();

            var response = _mapper.Map<CreateQuestionVm>(application);
            var partList = await _partService.GetPartListAsync();
            foreach (var app in partList)
            {
                parts.Add(
                    new SelectListItem
                    {
                        Text = app.Title,
                        Value = app.Id.ToString(),
                        Selected = app.Id == response.Id
                    }
                );
            }
            response.Parts = parts;
            return View(Constants.CreateAction, response);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Question question)
        {
            TempData[Constants.IsShow] = "";
            var result = await _questionService.UpdateQuestionAsync(question);
            if (result)
            {
                TempData[Constants.IsShow] = "Part updated successfully.";
            }
            else
            {
                TempData[Constants.IsShow] = "We have some problem in update this question.";
                _logger.LogError($"{Constants.UserError}: \"We have some problem in update this question.");
            }
            var response = await _questionService.GetQuestionsAsync();
            return RedirectToAction(Constants.IndexAction, response);
        }

        public async Task<IActionResult> Delete(int questionId)
        {
            TempData[Constants.IsShow] = "";
            var result = await _questionService.DeleteQuestionAsync(questionId);
            if (!result)
            {
                TempData[Constants.IsShow] = $"{Constants.UserError} : This Part has items and You can not delete it";
                _logger.LogError($"{Constants.UserError}: This Part has items and You can not delete it");
            }
            var response = await _questionService.GetQuestionsAsync();
            return RedirectToAction(Constants.IndexAction, response);
        }

        public async Task<IActionResult> ToggleActivation(int QuestionId, bool CurrentStatus)
        {
            var result = await _questionService.ToggleActivationAsync(QuestionId, CurrentStatus);
            if (result)
            {
                TempData[Constants.IsShow] = "Part updated successfully.";
            }
            else
            {
                TempData[Constants.IsShow] = "We have some problem in update this question.";
                _logger.LogError($"{Constants.UserError}: \"We have some problem in update this question.");
            }
            var response = await _questionService.GetQuestionsAsync();
            return RedirectToAction(Constants.IndexAction, response);
        }
    }
}
