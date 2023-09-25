using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public string Index(int id)
        {
            var result_str = ProductsRepository.SearchProductById(id); 
            return result_str;
        }
    }
}
