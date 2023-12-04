using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop_WebApp.Mappings;

namespace OnlineShop_WebApp.Views.Shared.Components.Cart
{
    public class Cart : ViewComponent
    {
        private readonly ICartsRepository cartsRepository;

        public Cart(ICartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetByUserId(User.Identity.Name);
            var cartViewModel = Mapping.ToCartViewModel(cart);

            var productCounts = cartViewModel?.Amount ?? 0;

            return View("Cart", productCounts);
        }
    }
}
