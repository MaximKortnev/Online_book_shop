using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AuthController : Controller
    {

        private readonly IUsersRepository userRepository;
        public AuthController(IUsersRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Index", user);
        }

        [HttpPost]
        public IActionResult Registration(User user)
        {

            if (ModelState.IsValid)
            {
                userRepository.Add(user);
                return RedirectToAction("Index", "Home");
            }
            return View("Index", user);
        }
    }
}
