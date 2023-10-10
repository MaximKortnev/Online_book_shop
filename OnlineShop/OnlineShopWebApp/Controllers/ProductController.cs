using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
        public ProductController(IProductsRepository productsRepository) 
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Index(int productId)
        {
            var productCard = productsRepository.TryGetProductById(productId);

            if (productCard == null) { return View("ErrorProduct");}
            return View(productCard);
        }
    }
}
