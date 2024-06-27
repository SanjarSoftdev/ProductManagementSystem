using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using ProductManagementSystem.Model.Entities;
using ProductManagementSystem.Services;
using ProductManagementSystem.ViewModels.User;

namespace Znak.Controllers
{
    public class AdminController : ControllerBase
    {
        public AdminController(IAuthenticationUser authentication) : base(authentication)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Admin(LoginViewModel loginViewModel)
        {
            try
            {
                User user = Authentication.SignIn(loginViewModel.Login, loginViewModel.Password).Result;
                if (user != null)
                    return View(user);
            }
            catch
            {
            }
            return RedirectToAction("", nameof(User));
        }
    }
}
