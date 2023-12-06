using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Models;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db;
using OnlineShop_WebApp.Mappings;
using Microsoft.AspNetCore.Authorization;

namespace OnlineShop_WebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly IWebHostEnvironment appEnvironment;
        public ProductsController(IProductsRepository productRepository, IWebHostEnvironment appEnvironment)
        {
            this.productRepository = productRepository;
            this.appEnvironment = appEnvironment;
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
                if (product.ImageFiles != null && product.ImageFiles.Any())
                {
                    var imagePaths = FileManager.PathImagesForProduct(product, appEnvironment);
                    product.ImagePath = imagePaths.FirstOrDefault();
                    product.ImagePaths = imagePaths;

                    var productDB = Mapping.ToProductDB(product);
                    productRepository.Edit(productDB);
                    return RedirectToAction("GetProducts", "Home");
                }
            }
            return View("ViewEdit", product);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                if (product.ImageFiles != null && product.ImageFiles.Any())
                {
                    var imagePaths = FileManager.PathImagesForProduct(product, appEnvironment);
                    product.ImagePath = imagePaths.FirstOrDefault();
                    product.ImagePaths = imagePaths;
                    productRepository.Add(Mapping.ToProductDB(product));
                    return RedirectToAction("GetProducts", "Home");
                }
            }
            foreach (var key in ModelState.Keys)
            {
                var modelStateEntry = ModelState[key];
                foreach (var error in modelStateEntry.Errors)
                {
                    Console.WriteLine($"Error in field '{key}': {error.ErrorMessage}");
                }
            }
            Console.WriteLine("111");
            return View("AddProduct", product);
        }
    }
}
