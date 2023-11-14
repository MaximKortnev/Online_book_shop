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
        [HttpPost]
        public IActionResult Save()
        {

            adminUsers.EditRole();
            return RedirectToAction("GetUsers", "Admin");
        }
        public IActionResult Delete(Guid Id)
        {
            adminUsers.Delete(Id);
            return RedirectToAction("GetUsers", "Admin");
        }
    }
}
