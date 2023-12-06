using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Interfaces;
using OnlineShop_WebApp.Models;
using OnlineShop.Db;

namespace OnlineShop_WebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UsersController : Controller
    {
        private readonly IAdminUsersFunctions adminUsers;
        private readonly IRolesRepository rolesRepository;
        public UsersController(IAdminUsersFunctions adminUsers, IRolesRepository rolesRepository)
        {
            this.adminUsers = adminUsers;
            this.rolesRepository = rolesRepository;
        }

        public IActionResult Info(Guid Id)
        {
            ViewBag.AllRoles = rolesRepository.GetAll();
            var user = adminUsers.TryGetById(Id);
            if (user != null)
            {
                return View(user);
            }
            return View("ExistUser");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                adminUsers.Add(user);
                return RedirectToAction("GetUsers", "Home");
            }
            return View("Add", user);
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

        public IActionResult Delete(Guid Id)
        {
            var user = adminUsers.TryGetById(Id);
            if (user != null)
            {
                adminUsers.Delete(Id);
                return RedirectToAction("GetUsers", "Home");
            }
            return View("ExistUser");

        }

        public IActionResult EditPassword(Guid Id)
        {
            var user = adminUsers.TryGetById(Id);
            if (user != null)
            {
                return View(user);
            }
            return View("ExistUser");
        }

        [HttpPost]
        public IActionResult EditPassword(Guid Id, string password)
        {
            if (ModelState.IsValid)
            {
                var user = adminUsers.TryGetById(Id);
                if (user != null)
                {
                    adminUsers.EditPassword(Id, password);
                    return RedirectToAction("GetUsers", "Home");
                }
                return View("ExistUser");
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
