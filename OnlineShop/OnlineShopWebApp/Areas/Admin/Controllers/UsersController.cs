using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using System;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IAdminUsersFunctions adminUsers;
        private readonly IRolesRepository roleRepository;
        public UsersController(IAdminUsersFunctions adminUsers, IRolesRepository roleRepository)
        {
            this.adminUsers = adminUsers;
            this.roleRepository = roleRepository;
        }

        public IActionResult Info(Guid Id)
        {
            ViewBag.AllRoles = roleRepository.GetAll();
            var user = adminUsers.TryGetById(Id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Save(Guid Id, string role)
        {
            var correctRole = roleRepository.GetAll().FirstOrDefault(x => x.Name == role);
            if (correctRole == null) { return View("BadRole"); }
            var user = adminUsers.TryGetById(Id);
            user.Role.Name = role;
            adminUsers.EditRole(user);
            return RedirectToAction("GetUsers", "Home");
        }
        public IActionResult Delete(Guid Id)
        {
            adminUsers.Delete(Id);
            return RedirectToAction("GetUsers", "Home");
        }
    }
}
