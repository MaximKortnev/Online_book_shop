using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    public class AdminRolesController : Controller
    {
        private readonly IRolesRepository rolesRepository;
        public AdminRolesController(IRolesRepository rolesRepository)
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
                return RedirectToAction("GetRoles", "Administrator");
            }
            return View("Add", role);
        }

        public IActionResult Delete(string name)
        {
            rolesRepository.Delete(name);
            return RedirectToAction("GetRoles", "Administrator");
        }
    }
}
