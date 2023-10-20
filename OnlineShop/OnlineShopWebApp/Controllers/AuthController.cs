using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Registration(string login, string email, string password, string confirmPassword, string username)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
