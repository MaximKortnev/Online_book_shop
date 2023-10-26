using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfaces
{
    public interface IOrdersRepository
    {
        void SaveToFileOrders(OrderData orderData, string userId, Cart existingCart);
        OrderData TryGetByUserId(string userId);
        void Add(Cart cart, string userId);
    }
}
