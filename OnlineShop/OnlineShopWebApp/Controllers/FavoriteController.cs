using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class FavoriteController : Controller
    {

        private readonly IProductsRepository productsRepository;
        private readonly IFavoritesRepository favoriteRepository;
        public FavoriteController(IProductsRepository productsRepository, IFavoritesRepository favoriteRepository)
        {
            this.favoriteRepository = favoriteRepository;
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var favorite = favoriteRepository.TryGetByUserId(Constants.UserId);
            return View(favorite);
        }

        public IActionResult Add(int productId) {
            var productCard = productsRepository.TryGetProductById(productId);
            favoriteRepository.Add(productCard, Constants.UserId);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Decrease(int productId)
        {
            var product = productsRepository.TryGetProductById(productId);
            if (product == null) { return View("ErrorAddCart"); }
            favoriteRepository.Decrease(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            favoriteRepository.Clear();
            return RedirectToAction("Index");
        }
    }
}
