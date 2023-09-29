using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public string Index(int id)
        {
            var productCard = ProductsRepository.TryGetProductById(id);

            if (productCard == null) { return "Такого тавара нет";}
            return $"{productCard}\nDescription: {productCard.Description}";
        }
    }
}
