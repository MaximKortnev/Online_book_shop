using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using System;

namespace OnlineShop_WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
        public ProductController(IProductsRepository productsRepository) 
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Index(Guid productId)
        {
            var productCard = productsRepository.TryGetProductById(productId);

            if (productCard == null) { return View("ErrorProduct");}
            return View(productCard);
        }

    }
}
