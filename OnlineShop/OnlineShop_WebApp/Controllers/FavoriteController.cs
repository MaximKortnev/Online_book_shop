﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop_WebApp.Mappings;
using OnlineShop.Db;

namespace OnlineShop_WebApp.Controllers
{
    [Authorize]
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
            var favorite = favoriteRepository.GetAll(User.Identity.Name);
            var favoriteViewModel = Mapping.ToProductViewModels(favorite);
            return View(favoriteViewModel);
        }

        public IActionResult Add(Guid productId) {
            var product = productsRepository.TryGetProductById(productId);
            if (product == null) return View("ErrorFavorite");
            favoriteRepository.Add(product, User.Identity.Name);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Decrease(Guid productId)
        {
            var product = productsRepository.TryGetProductById(productId);
            if (product == null) { return View("ErrorFavorite"); }
            favoriteRepository.Decrease(product, User.Identity.Name);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Clear()
        {
            favoriteRepository.Clear(User.Identity.Name);
            return RedirectToAction("Index");
        }
    }
}
