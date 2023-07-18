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
    public class QuestionItemController : Controller
    {
        private readonly IQuestionItemService _questionItemService;
        private readonly IQuestionService _questionService;
        private readonly ILogger<QuestionItemController> _logger;

        public QuestionItemController(IQuestionItemService questionItemService, ILogger<QuestionItemController> logger, IQuestionService questionService)
        {
            _questionItemService = questionItemService;
            _logger = logger;
            _questionService = questionService;
        }

        public async Task<IActionResult> Index(int QuestionId)
        {
            var response = await _questionService.GetQuestionIncludeItemsAsync(QuestionId);
            return View(response);
        }

        [HttpGet]
        public IActionResult Create(int QuestionId)
        {
            ViewData["Action"] = Constants.CreateAction;

            var response = new QuestionItem();
            response.QuestionId = QuestionId;
            return View(Constants.CreateAction, response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(QuestionItem item)
        {
            TempData[Constants.IsShow] = "";
            item.IsActive = true;
            var result = await _questionItemService.AddQuestionItemtAsync(item);
            if (result)
            {
                TempData[Constants.IsShow] = "Item Added successfully.";
            }
            else
            {
                TempData[Constants.IsShow] = "We have some problem in creating this Item.";
                _logger.LogError($"{Constants.UserError}: \"We have some problem in creating this Item.");

            }

            return RedirectToAction(Constants.IndexAction, new { QuestionId = item.QuestionId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int ItemId)
        {
            ViewData["Action"] = Constants.EditAction;
            var item = await _questionItemService.GetQuestionItemsAsync(ItemId);

            return View(Constants.CreateAction, item);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(QuestionItem item)
        {
            TempData[Constants.IsShow] = "";
            var result = await _questionItemService.UpdateQuestionItemAsync(item);
            if (result)
            {
                TempData[Constants.IsShow] = "Item updated successfully.";
            }
            else
            {
                TempData[Constants.IsShow] = "We have some problem in update this Item .";
                _logger.LogError($"{Constants.UserError}: \"We have some problem in update this Item .");
            }

            return RedirectToAction(Constants.IndexAction, new { QuestionId = item.QuestionId });
        }

        public async Task<IActionResult> Delete(int ItemId)
        {
            TempData[Constants.IsShow] = "";
            var item = await _questionItemService.GetQuestionItemAsync(ItemId);
            var result = await _questionItemService.DeleteQuestionItemAsync(ItemId);
            if (!result)
            {
                TempData[Constants.IsShow] = $"{Constants.UserError} : This Part has Question and You can not delete it";
                _logger.LogError($"{Constants.UserError}: This Part has Question and You can not delete it");
            }

            return RedirectToAction(Constants.IndexAction, new { QuestionId = item.QuestionId });
        }

        public async Task<IActionResult> Toggle(int ItemId, bool CurrentStatus)
        {
            var item = await _questionItemService.GetQuestionItemAsync(ItemId);
            var result = await _questionItemService.ToggleActivationAsync(ItemId, CurrentStatus);
            if (result)
            {
                TempData[Constants.IsShow] = "Item updated successfully.";
            }
            else
            {
                TempData[Constants.IsShow] = "We have some problem in update this item.";
                _logger.LogError($"{Constants.UserError}: \"We have some problem in update this item.");
            }

            return RedirectToAction(Constants.IndexAction, new { QuestionId = item.QuestionId });
        }

    }
}
