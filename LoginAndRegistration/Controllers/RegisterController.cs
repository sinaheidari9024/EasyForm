using EasyForm.Entities;
using EasyForm.Enum;
using EasyForm.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EasyForm.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public RegisterController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterVm req)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = req.Email,
                    Email = req.Email,
                    Role = UserRole.NormalUser
                };
                var claim = new Claim(ClaimTypes.Role.ToString(), user.Role.ToString());
                var result = await _userManager.CreateAsync(user, req.Password);
                await _userManager.AddClaimAsync(user, claim);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
    }
}
