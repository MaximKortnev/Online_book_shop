using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Interfaces;
using OnlineShop.Db.Interfaces;
using OnlineShop_WebApp.Mappings;

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
            var сomparison = сomparisonRepository.GetAll(Constants.UserId);
            var comparisonViewModel = Mapping.ToProductViewModels(сomparison);
            return View(comparisonViewModel);
        }

        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetProductById(productId);
            if (product == null) { return View("ErrorComparison"); }
            сomparisonRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(Guid productId)
        {
            var product = productsRepository.TryGetProductById(productId);
            if (product == null) { return View("ErrorComparison"); }
            сomparisonRepository.Delete(product, Constants.UserId);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Clear(string userId)
        {
            сomparisonRepository.Clear(Constants.UserId);
            return RedirectToAction("Index", "Home");
        }
    }
}
