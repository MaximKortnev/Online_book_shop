using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Interfaces;
using OnlineShop_WebApp.Models;
using System.Linq;

namespace OnlineShop_WebApp.Controllers
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
                var roles = roleRepository.GetAll();
                user.Role = roles.FirstOrDefault(x=> x.Name.ToLower() == "пользователь");
                if (user.Role == null)
                {
                    var role = new Roles();
                    role.Name = "Пользователь";
                    roleRepository.Add(role);
                    user.Role = role;
                }
                userRepository.Add(user);
                return RedirectToAction("Index", "Home");
            }
            return View("Index", user);
        }
    }
}
