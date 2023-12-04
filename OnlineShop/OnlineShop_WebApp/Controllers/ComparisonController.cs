using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop_WebApp.Mappings;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Db;

namespace OnlineShop_WebApp.Controllers
{
    [Authorize]
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
            var сomparison = сomparisonRepository.GetAll(User.Identity.Name);
            var comparisonViewModel = Mapping.ToProductViewModels(сomparison);
            return View(comparisonViewModel);
        }

        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetProductById(productId);
            if (product == null) { return View("ErrorComparison"); }
            сomparisonRepository.Add(product, User.Identity.Name);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(Guid productId)
        {
            var product = productsRepository.TryGetProductById(productId);
            if (product == null) { return View("ErrorComparison"); }
            сomparisonRepository.Delete(product, User.Identity.Name);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Clear()
        {
            сomparisonRepository.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
