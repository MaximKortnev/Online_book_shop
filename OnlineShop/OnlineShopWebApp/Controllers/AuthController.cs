using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class AuthController : Controller
    {

        private readonly IUsersRepository userRepository;
        private readonly IRolesRepository roleRepository;

        public AuthController(IUsersRepository userRepository, IRolesRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
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
                var validUser = userRepository.TryGetByLogin(user.Login);
                if (validUser != null) { 
                    if (user.Password == validUser.Password) { 
                        return View();
                    }
                    ModelState.AddModelError(string.Empty, "Неверный логин или пароль");
                    return View("IncorrectPassword", user);
                }
                return RedirectToAction("Index", "Home");
            }
            return View("Index", user);
        }

        [HttpPost]
        public IActionResult Registration(User user)
        {

            if (ModelState.IsValid)
            {
                user.Role = roleRepository.GetAll().FirstOrDefault(x=> x.Name.ToLower() == "пользователь");
                userRepository.Add(user);
                return RedirectToAction("Index", "Home");
            }
            return View("Index", user);
        }
    }
}
