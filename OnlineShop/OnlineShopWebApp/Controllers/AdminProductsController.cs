using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class AdminProductsController : Controller
    {
        private readonly IProductsRepository productRepository;
        public AdminProductsController(IProductsRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Edit(int productId)
        {
            var product = productRepository.TryGetProductById(productId);
            return View(product);
        }
        public void Delete()
        {
        }


        [HttpPost]
        public void Save() { }
    }
}
