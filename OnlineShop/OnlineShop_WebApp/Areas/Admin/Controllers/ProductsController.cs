using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Interfaces;
using OnlineShop_WebApp.Models;
using OnlineShop.Db.Interfaces;
using OnlineShop_WebApp.Mappings;

namespace OnlineShop_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly IAdminProductsFunctions adminProductFunction;
        public ProductsController(IProductsRepository productRepository, IAdminProductsFunctions adminProductFunction)
        {
            this.productRepository = productRepository;
            this.adminProductFunction = adminProductFunction;
        }

        public IActionResult ViewEdit(Guid productId)
        {
            var product = productRepository.TryGetProductById(productId);
            if (product != null) { return View(product); }
            return View("ErrorProduct");
        }
        public IActionResult Delete(Guid productId)
        {
            //var product = productRepository.TryGetProductById(productId);
            //if (product != null)
            //{
            //    adminProductFunction.Delete(productId);
            //    return RedirectToAction("GetProducts", "Home");
            //}
            return View("ErrorProduct");
        }
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveEdit(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                adminProductFunction.Edit(product);
                return RedirectToAction("GetProducts", "Home");
            }
            return View("ViewEdit", product);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                productRepository.Add(Mapping.ToProductDB(product));
                return RedirectToAction("GetProducts", "Home");
            }
            return View("AddProduct", product);
        }
    }
}
