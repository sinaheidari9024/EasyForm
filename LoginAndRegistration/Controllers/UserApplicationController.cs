using EasyForm.Services.Contracts;
using EasyForm.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EasyForm.Controllers
{
    public class UserApplicationController : Controller
    {
        private readonly IUserApplicationService _userApplicationService;

        public UserApplicationController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }


        public async Task<IActionResult> Index(DataGridSearch dataGridSearch)
        {
            var response = await _userApplicationService.GetUserApplicationsAsync(dataGridSearch);
            return View(response);
        }
    }
}
