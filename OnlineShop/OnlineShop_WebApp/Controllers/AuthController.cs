using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Interfaces;
using OnlineShop_WebApp.Models;
using OnlineShop.Db.Models;

namespace OnlineShop_WebApp.Controllers
{
    public class AuthController : Controller
    {

        private readonly IUsersRepository userRepository;
        private readonly IRolesRepository roleRepository;
        //private readonly IUserManager userManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _singInManager;

        public AuthController(IUsersRepository userRepository, IRolesRepository roleRepository, SignInManager<User> singInManager, UserManager<User> _userManager)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            _singInManager = singInManager;
            this._userManager = _userManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                var result = _singInManager.PasswordSignInAsync(loginUser.Login, loginUser.Password, loginUser.rememberMe, false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Неправильный пароль");
            }
            return View("Login", loginUser);
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(UserViewModel userView)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = userView.Login, Email = userView.Email };
                var result = await _userManager.CreateAsync(user, userView.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Пользователь");
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("Registration", userView);
        }
        public IActionResult Logout()
        {
            _singInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }
    }
}
