using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShop_WebApp.Models;

namespace OnlineShop_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productsRepository;
        public HomeController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModels = new ProductViewModel
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
                productsViewModels.Add(productViewModels);
            }
            return View(productsViewModels);
        }

        [HttpPost]
        public IActionResult Search(string productName)
        {
            var products = productsRepository.GetAll().Where(p => p.Name.Contains(productName)).ToList();
            if (products == null) { View("ErrorPdoduct", "Product"); }
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModels = new ProductViewModel
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
                productsViewModels.Add(productViewModels);
            }
            return View(productsViewModels);
        }
    }
}