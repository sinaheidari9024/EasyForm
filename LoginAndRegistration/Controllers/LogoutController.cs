using EasyForm.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EasyForm.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        public LogoutController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult DontLogout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
