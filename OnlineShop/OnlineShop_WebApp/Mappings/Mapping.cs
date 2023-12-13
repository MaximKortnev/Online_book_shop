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
                ImagePaths = product.ImagePaths
            };
            return productViewModel;
        }

        public static Product ToProductDB(ProductViewModel product)
        {
            var productDB = new Product
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
                ImagePaths= product.ImagePaths
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
        public static List<CartItem> ToCartItemDB(List<CartItemViewModel> cartItems)
        {
            var cartItemsDB = new List<CartItem>();
            foreach (var cartDbItem in cartItems)
            {
                var cartItem = new CartItem
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = ToProductDB(cartDbItem.Product)
                };
                cartItemsDB.Add(cartItem);
            }
            return cartItemsDB;
        }

        public static Order ToOrderDB(OrderViewModel order)
        {
            var orderDB = new Order
            {
                Id = order.Id,
                UserId = order.UserId,
                FullName = order.FullName,
                Address = order.Address,
                Phone = order.Phone,
                Email = order.Email,
                DeliveryMethod = order.DeliveryMethod,
                PaymentMethod = order.PaymentMethod,
                PromoCode = order.PromoCode,
                TotalCost = order.TotalCost,
                Status = (OrderStatus)(OrderStatusViewModel)(int)order.Status,
                Data = order.Data
            };
            return orderDB;
        }
        public static OrderViewModel ToOrderViewModel(Order order)
        {
            var orderViewModel = new OrderViewModel
            {
                Id = order.Id,
                UserId = order.UserId,
                FullName = order.FullName,
                Address = order.Address,
                Phone = order.Phone,
                Email = order.Email,
                DeliveryMethod = order.DeliveryMethod,
                PaymentMethod = order.PaymentMethod,
                PromoCode = order.PromoCode,
                TotalCost = order.TotalCost,
                ListProducts = ToCartItemViewModels(order.ListProducts),
                Status = (OrderStatusViewModel)(OrderStatus)(int)order.Status,
                Data = order.Data
            };
            return orderViewModel;
        }

        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                Login = user.UserName,
                Email = user.Email,
                NickName = user.NickName,
                AvatarImagePath = user.AvatarImagePath
            };
        }
    }
}







