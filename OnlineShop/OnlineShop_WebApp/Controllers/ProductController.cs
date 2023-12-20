using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop_WebApp.Models;


namespace OnlineShop_WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IMapper mapper;
        public ProductController(IProductsRepository productsRepository, IMapper mapper) 
        {
            this.productsRepository = productsRepository;
            this.mapper = mapper;
        }

        public IActionResult Index(Guid productId)
        {
            var product = productsRepository.TryGetProductById(productId);

            if (product == null) { return View("ErrorProduct");}
            var productViewModel = mapper.Map<ProductViewModel>(product);
            return View(productViewModel);
        }

    }
}
