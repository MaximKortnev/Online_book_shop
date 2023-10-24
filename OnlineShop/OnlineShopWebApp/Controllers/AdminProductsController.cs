using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

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
            if (product == null)
            {
                return View("~/Views/Product/ErrorProduct.cshtml");
            }
            return View(product);
        }
        public IActionResult Delete(int productId)
        {
            if (productRepository.TryGetProductById(productId) == null)
            {
                return View("~/Views/Product/ErrorProduct.cshtml");
            }
            adminProductFunction.Delete(productId, productRepository.GetAll());
            return RedirectToAction("GetProducts", "Administrator");
        }
        public IActionResult AddProduct()
        {
            var products = productRepository.GetAll();
            var newId = products[products.Count - 1].Id + 1;
            return View(newId);
        }

        [HttpPost]
        public IActionResult SaveEdit(Product product)
        {
            if (productRepository.TryGetProductById(product.Id) == null)
            {
                return View("~/Views/Product/ErrorProduct.cshtml");
            }
            adminProductFunction.Edit(product, productRepository.GetAll());
            return RedirectToAction("GetProducts", "Administrator");
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (productRepository.TryGetProductById(product.Id) == null)
            {
                return View("~/Views/Product/ErrorProduct.cshtml");
            }
            adminProductFunction.Add(product, productRepository.GetAll());
            return RedirectToAction("GetProducts", "Administrator");
        }
    }
}
