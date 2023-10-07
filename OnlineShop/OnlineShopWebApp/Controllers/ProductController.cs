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

        public IActionResult Index(int id)
        {
            var productCard = productsRepository.TryGetProductById(id);

            if (productCard == null || productCard.Id != id) { return View("ErrorProduct");}
            return View(productCard);
        }
    }
}
