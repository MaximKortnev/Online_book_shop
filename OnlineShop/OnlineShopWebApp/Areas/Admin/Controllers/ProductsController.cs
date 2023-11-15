﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

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

        public IActionResult ViewEdit(int productId)
        {
            var product = productRepository.TryGetProductById(productId);
            return View(product);
        }
        public IActionResult Delete(int productId)
        {
            adminProductFunction.Delete(productId);
            return RedirectToAction("GetProducts", "Home");
        }
        public IActionResult AddProduct()
        {
            var products = productRepository.GetAll();
            ViewBag.ProductId = products.Count + 1;
            return View();
        }

        [HttpPost]
        public IActionResult SaveEdit(Product product)
        {
            if (ModelState.IsValid)
            {
                adminProductFunction.Edit(product);
                return RedirectToAction("GetProducts", "Home");
            }
            else { return View("ViewEdit", product); }
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                adminProductFunction.Add(product);
                return RedirectToAction("GetProducts", "Home");
            }
            else { return View("AddProduct", product); }
        }
    }
}