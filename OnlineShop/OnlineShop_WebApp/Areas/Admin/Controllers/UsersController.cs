using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Interfaces;
using OnlineShop_WebApp.Models;
using OnlineShop_WebApp.Mappings;
using OnlineShop.Db.Models;
using OnlineShop.Db;
using Microsoft.AspNetCore.Identity;
using OnlineShop_WebApp.Areas.Admin.Models;


namespace OnlineShop_WebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UsersController : Controller
    {
        private readonly IAdminUsersFunctions adminUsers;
        private readonly RoleManager<IdentityRole> rolesManager;

        private readonly UserManager<User> usersManager;
        public UsersController(IAdminUsersFunctions adminUsers, RoleManager<IdentityRole> rolesManager, UserManager<User> usersManager)
        {
            this.adminUsers = adminUsers;
            this.usersManager = usersManager;
            this.rolesManager = rolesManager;
        }

        public IActionResult Info(string name)
        {
            var roles = rolesManager.Roles.ToList();
            ViewBag.AllRoles = roles.Select(x => new RoleViewModel { Name = x.Name }).ToList();
            
            var user = usersManager.FindByNameAsync(name).Result;
            if (user != null)
            {
                return View(user.ToUserViewModel());
            }
            return View("ExistUser");
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Save(Guid Id, string role)
        {
            var correctRole = rolesRepository.GetAll().FirstOrDefault(x => x.Name == role);
            if (correctRole == null) { return View("BadRole"); }
            var user = adminUsers.TryGetById(Id);
            if (user != null)
            {
                user.Role.Name = role;
                adminUsers.EditRole(user);
                return RedirectToAction("GetUsers", "Home");
            }
            return View("ExistUser");
        }

        public IActionResult Delete(string name)
        {
            var user = usersManager.FindByNameAsync(name).Result;
            if (user != null)
            {
                usersManager.DeleteAsync(user).Wait();
                return RedirectToAction("GetUsers", "Home");
            }
            return View("ExistUser");

        }

        public IActionResult EditPassword(string name)
        {
            var changePassword = new ChangePassword()
            {
                UserName = name
            };
            return View(changePassword);

        }

        [HttpPost]
        public IActionResult EditPassword(ChangePassword changePassword)
        {
            if (ModelState.IsValid)
            {
                var user = usersManager.FindByNameAsync(changePassword.UserName).Result;
                if (user == null)
                {
                    return View("ExistUser");
                }
                var newHashPassword = usersManager.PasswordHasher.HashPassword(user, changePassword.Password);
                user.PasswordHash = newHashPassword;
                usersManager.UpdateAsync(user).Wait();
                return RedirectToAction("GetUsers", "Home");
            }
            return View();
        }
        public IActionResult Edit(Guid Id)
        {
            ViewBag.AllRoles = rolesRepository.GetAll();
            var user = adminUsers.TryGetById(Id);
            if (user != null)
            {
                return View(user);
            }
            return View("ExistUser");
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel user, string role)
        {
            if (ModelState.IsValid)
            {
                user.Role = rolesRepository.GetAll().FirstOrDefault(x => x.Name == role);
                adminUsers.Edit(user);
                return RedirectToAction("GetUsers", "Home");
            }
            return View("Edit", user);
        }

    }
}
