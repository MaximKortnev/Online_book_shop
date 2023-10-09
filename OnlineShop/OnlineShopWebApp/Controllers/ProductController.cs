using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Repositories;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsRepository productsRepository;
        public ProductController(ProductsRepository productsRepository) 
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Index(int productId)
        {
            var productCard = productsRepository.TryGetProductById(productId);

            if (productCard == null || productCard.Id != productId) { return View("ErrorProduct");}
            return View(productCard);
        }
    }
}
