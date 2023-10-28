using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IOrdersRepository
    {
        void SaveOrders(OrderData orderData, string userId, Cart existingCart);
        OrderData TryGetByUserId(string userId);
        void Add(Cart cart, string userId);
        List<OrderData> GetAll();
    }
}
