using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop_WebApp.Mappings;


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
            var productViewModel = Mapping.ToProductViewModel(product);
            return View(productViewModel);
        }

    }
}
