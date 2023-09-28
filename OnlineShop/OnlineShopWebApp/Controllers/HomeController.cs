using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public string Index() => ProductRepository.GetProductsData();
    }
}
