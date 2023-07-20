using ClosedXML.Excel;
using EasyForm.Services.Contracts;
using EasyForm.ViewModel;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Controllers
{
    public class UserApplicationController : Controller
    {
        private readonly IUserApplicationService _userApplicationService;
        private readonly IQuestionService _questionService;

        public UserApplicationController(IUserApplicationService userApplicationService, IQuestionService questionService)
        {
            _userApplicationService = userApplicationService;
            _questionService = questionService;
        }


        public async Task<IActionResult> Index(DataGridSearch dataGridSearch, int? page)
        {
            var response = await _userApplicationService.GetUserApplicationsAsync(dataGridSearch);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> DownloadExcel(int userApplicationId)
        {
            var result = await _questionService.GetQuestionIncludeItemsAndAnswerAsync(userApplicationId);

            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Question"), new DataColumn("Answer") });
            foreach (var item in result)
            {
                if(item.Type != Enum.QuestionType.Note)
                {
                    if((item.Type == Enum.QuestionType.DropDown || item.Type == Enum.QuestionType.OptionBox) && item.Answer != null)
                    {
                        var answer = item.Items.FirstOrDefault(s => s.Id == Convert.ToInt32(item.Answer)).Title;
                        dt.Rows.Add(item.Text, item.Answer);
                    }
                    else if (item.Type == Enum.QuestionType.CheckBox && item.Answer != null)
                    {
                        List<int> answers = item.Text.Split(',').Select(int.Parse).ToList();
                        string stringAnswer =  string.Empty;
                        foreach (var answer in answers)
                        {
                            stringAnswer = stringAnswer + item.Items.FirstOrDefault(s => s.Id == answer).Title + " , ";
                        }
                        dt.Rows.Add(item.Text, stringAnswer);

                    }
                    else if (item.Type == Enum.QuestionType.Boolean)
                    {
                        if(item.Answer == "true")
                        {
                            dt.Rows.Add(item.Text, "Yes");

                        }else if (item.Answer == "false")
                        {
                            dt.Rows.Add(item.Text, "No");
                        }
                        else
                        {
                            dt.Rows.Add(item.Text, item.Answer);
                        }
                    }
                        dt.Rows.Add(item.Text, item.Answer);
                }
            }

            using XLWorkbook wb = new();
            wb.Worksheets.Add(dt);
            using (MemoryStream stream = new())
            {
                wb.SaveAs(stream);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Application.xlsx");
            }
            
        }
    }
}
