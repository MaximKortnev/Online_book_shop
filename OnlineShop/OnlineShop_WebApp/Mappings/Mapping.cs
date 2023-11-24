using OnlineShop.Db.Models;
using OnlineShop_WebApp.Models;

namespace OnlineShop_WebApp.Mappings
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(List<Product> products)
        {

            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }

        public static ProductViewModel ToProductViewModel(Product product)
        {
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Author = product.Author,
                AboutTheBook = product.AboutTheBook,
                AboutAuthor = product.AboutAuthor,
                Quote = product.Quote,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath,
            };
            return productViewModel;
        }

        public static Product ToProductDB(ProductViewModel product)
        {
            var productDB = new Product
            {
                Name = product.Name,
                Author = product.Author,
                AboutTheBook = product.AboutTheBook,
                AboutAuthor = product.AboutAuthor,
                Quote = product.Quote,
                Cost = product.Cost,
                Description = product.Description
            };
            return productDB;
        }

        public static CartViewModel ToCartViewModel(Cart cart)
        {
            if (cart == null) { return null; }
            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartItemViewModels(cart.Items)
            };
        }


        public static List<CartItemViewModel> ToCartItemViewModels(List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemViewModel>();
            foreach (var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = ToProductViewModel(cartDbItem.Product)
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }

    }
}







