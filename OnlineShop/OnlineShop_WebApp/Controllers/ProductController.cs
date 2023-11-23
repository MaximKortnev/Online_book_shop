using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShop_WebApp.Models;

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
            var product = productsRepository.TryGetProductById(productId);

            if (product == null) { return View("ErrorProduct");}
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Author = product.Author,
                AboutTheBook = product.AboutTheBook,
                AboutAuthor = product.AboutAuthor,
                Quote = product.Quote,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath,
            };
            return View(productViewModel);
        }

    }
}
