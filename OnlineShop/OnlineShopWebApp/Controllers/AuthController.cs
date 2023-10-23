using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string password, bool rememberMe) 
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Registration(User user,  string confirmPassword)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
