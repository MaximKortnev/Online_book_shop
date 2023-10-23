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
        public IActionResult Login(LoginUser user) 
        {
            if (ModelState.IsValid)
            {
                //Поиск пользователя
                return Ok();
            }  
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Registration(User user)
        {

            if (ModelState.IsValid) {
                return Ok();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
