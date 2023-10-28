using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class AdminOrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
