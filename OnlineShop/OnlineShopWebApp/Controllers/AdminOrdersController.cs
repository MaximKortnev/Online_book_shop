using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Repositories;

namespace OnlineShopWebApp.Controllers
{
    public class AdminOrdersController : Controller
    {
        private readonly IOrdersRepository ordersRepository;
        public AdminOrdersController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Info()
        {
            var order = ordersRepository.TryGetByUserId(Constants.UserId);
            return View(order);
        }


    }
}
