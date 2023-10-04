﻿using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int id)
        {
            var productCard = ProductsRepository.TryGetProductById(id);

            if (productCard == null || productCard.Id != id) { return View("ErrorProduct");}
            return View(productCard);
        }
    }
}
