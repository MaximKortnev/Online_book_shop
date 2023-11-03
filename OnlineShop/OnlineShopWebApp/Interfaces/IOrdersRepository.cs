using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfaces
{
    public interface IOrdersRepository
    {
        void SaveOrder(Order orderData, string userId, Cart existingCart);
        Order TryGetByUserId(string userId);
        void AddToListOrders(Cart cart, string userId);
    }
}
