using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface IAdminOrdersFunctions
    {
        void EditStatus(Guid orderId, OrderStatus status);
        void Delete(Guid orderId);
    }
}
