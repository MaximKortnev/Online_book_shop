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
        public ProductsController(IProductsRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult ViewEdit(Guid productId)
        {
            var product = productRepository.TryGetProductById(productId);
            if (product == null)
            {
                return View("ErrorProduct");
            }
            var productViewModel = Mapping.ToProductViewModel(product);
            return View(productViewModel);
           
        }
        public IActionResult Delete(Guid productId)
        {
            var product = productRepository.TryGetProductById(productId);
            if (product != null)
            {
                productRepository.Delete(productId);
                return RedirectToAction("GetProducts", "Home");
            }
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
                var productDB = Mapping.ToProductDB(product);
                productRepository.Edit(productDB);
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
