using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUsersController : Controller
    {
        private readonly IAdminUsersFunctions adminUsers;
        public AdminUsersController(IAdminUsersFunctions adminUsers)
        {
            this.adminUsers = adminUsers;
        }

        public IActionResult Info(Guid Id)
        {
            var user = adminUsers.TryGetById(Id);
            return View(user);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            if (ModelState.IsValid)
            {
                adminUsers.Add(user);
                return RedirectToAction("GetUsers", "Admin");
            }
            return View("Add", user);
        }

        public IActionResult Delete(Guid Id)
        {
            adminUsers.Delete(Id);
            return RedirectToAction("GetUsers", "Admin");
        }
    }
}
