using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
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
            var carts = cartsRepository.TryGetByUserId(Constants.UserId);
            var productCounts = carts?.Amount ?? 0;
            
            return View("Cart", productCounts); 
        }
    }
}
