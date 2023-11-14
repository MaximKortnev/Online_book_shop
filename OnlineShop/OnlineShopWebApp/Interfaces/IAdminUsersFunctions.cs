using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface IAdminUsersFunctions
    {
        Order TryGetById(Guid Id);
        void EditStatus(Guid orderId, OrderStatus status);
        void Delete(Guid orderId);
    }
}
