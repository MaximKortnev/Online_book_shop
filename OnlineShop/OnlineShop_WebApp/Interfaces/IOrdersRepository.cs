using OnlineShop_WebApp.Models;
using OnlineShop.Db.Models;

namespace OnlineShop_WebApp.Interfaces
{
    public interface IOrdersRepository
    {
        void SaveOrders(Order orderData, string userId, CartViewModel existingCart);
        Order TryGetByUserId(string userId);
        void Add(CartViewModel cart, string userId);
        List<Order> GetAll();
        Order TryGetById(Guid Id);
    }
}
