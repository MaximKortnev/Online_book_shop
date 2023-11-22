using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShop.DataBase.Interfaces;
using System;
using OnlineShop.DataBase.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
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
        public IActionResult Delete(int productId)
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
            else { return View("ViewEdit", product); }
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productDB = new Product
                {
                    Name = product.Name,
                    Author = product.Author,
                    AboutTheBook = product.AboutTheBook,
                    AboutAuthor = product.AboutAuthor,
                    Quote = product.Quote,
                    Cost = product.Cost,
                    Description = product.Description,
                    ImagePath = product.ImagePath,
                };
                productRepository.Add(productDB);
                return RedirectToAction("GetProducts", "Home");
            }
            else { return View("AddProduct", product); }
        }
    }
}
