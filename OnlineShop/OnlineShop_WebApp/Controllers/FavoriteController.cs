using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Interfaces;
using OnlineShop.Db.Interfaces;

namespace OnlineShop_WebApp.Controllers
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

        public IActionResult Add(Guid productId) {
            var productCard = productsRepository.TryGetProductById(productId);
            if (productCard == null) return View("ErrorAddFavorite");
            favoriteRepository.Add(productCard, Constants.UserId);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Decrease(Guid productId)
        {
            var product = productsRepository.TryGetProductById(productId);
            if (product == null) { return View("ErrorAddFavorite"); }
            favoriteRepository.Decrease(product, Constants.UserId);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Clear()
        {
            favoriteRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
