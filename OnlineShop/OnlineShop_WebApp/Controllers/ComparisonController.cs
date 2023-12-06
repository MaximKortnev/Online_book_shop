using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Interfaces;
using OnlineShop.Db.Interfaces;

namespace OnlineShop_WebApp.Controllers
{
    public class ComparisonController : Controller
    {

        private readonly IProductsRepository productsRepository;
        private readonly IComparisonRepository сomparisonRepository;
        public ComparisonController(IComparisonRepository сomparisonRepository, IProductsRepository productsRepository)
        {
            this.сomparisonRepository = сomparisonRepository;
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var сomparison = сomparisonRepository.TryGetByUserId(Constants.UserId);
            return View(сomparison);
        }

        public IActionResult Add(Guid productId) {
            var productCard = productsRepository.TryGetProductById(productId);
            if (productCard == null) { return View("ErrorAddComparison");}
            //сomparisonRepository.Add(productCard, Constants.UserId);
            return RedirectToAction("Index", "Home");
        }
    }
}
