using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Admin;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System.ComponentModel;

namespace OnlineShopWebApp.Controllers
{
    public class AdminProductsController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly IAdminProductsFunctions adminProductFunction;
        public AdminProductsController(IProductsRepository productRepository, IAdminProductsFunctions adminProductFunction)
        {
            this.productRepository = productRepository;
            this.adminProductFunction = adminProductFunction;
        }

        public IActionResult ViewEdit(int productId)
        {
            var product = productRepository.TryGetProductById(productId);
            return View(product);
        }
        public IActionResult Delete(int productId)
        {
            adminProductFunction.Delete(productId, productRepository.GetAll());
            return RedirectToAction("GetProducts", "Administrator");
        }
        public IActionResult AddProduct()
        {
            if (ModelState.IsValid)
            {
                var id = productRepository.GetAll();
                return View(id.Count + 1);
            }
            else { return BadRequest(""); }
        }

        [HttpPost]
        public IActionResult SaveEdit(Product product)
        {
            if (ModelState.IsValid)
            {
                adminProductFunction.Edit(product, productRepository.GetAll());
                return RedirectToAction("GetProducts", "Administrator");
            }
            else { return BadRequest(); }
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                adminProductFunction.Add(product, productRepository.GetAll());
                return RedirectToAction("GetProducts", "Administrator");
            }
            else { return BadRequest(); }
        }
    }
}
