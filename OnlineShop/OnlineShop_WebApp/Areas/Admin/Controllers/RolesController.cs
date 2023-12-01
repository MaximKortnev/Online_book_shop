using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Interfaces;
using OnlineShop_WebApp.Models;
using OnlineShop.Db;

namespace OnlineShop_WebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RolesController : Controller
    {
        private readonly IRolesRepository rolesRepository;
        public RolesController(IRolesRepository rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Roles role)
        {
            if (rolesRepository.GetAll().Any(r => r.Name.ToLower() == role.Name.ToLower()))
            {
                ModelState.AddModelError("", "Роль с таким именем уже существует");
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Add(role);
                return RedirectToAction("GetRoles", "Home");
            }
            return View("Add", role);
        }

        public IActionResult Delete(string name)
        {
            rolesRepository.Delete(name);
            return RedirectToAction("GetRoles", "Home");
        }
    }
}
