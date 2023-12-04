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
                if (product.ImageFile != null)
                {
                    string productImagesPath = Path.Combine(appEnvironment.WebRootPath + "/images/products/");
                    if (!Directory.Exists(productImagesPath))
                    {
                        Directory.CreateDirectory(productImagesPath);
                    }

                    var filename = Guid.NewGuid() + "." + product.ImageFile.FileName.Split('.').Last();
                    using (var fileStream = new FileStream(productImagesPath + filename, FileMode.Create))
                    {
                        product.ImageFile.CopyTo(fileStream);
                    }
                    product.ImagePath = "/images/products/" + filename;
                    productRepository.Add(Mapping.ToProductDB(product));
                    return RedirectToAction("GetProducts", "Home");
                }
            }
            return View("AddProduct", product);
        }
    }
}
