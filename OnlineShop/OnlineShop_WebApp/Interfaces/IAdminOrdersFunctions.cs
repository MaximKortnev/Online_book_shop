using OnlineShop_WebApp.Models;
using System;

namespace OnlineShop_WebApp.Interfaces
{
    public interface IAdminOrdersFunctions
    {
        void EditStatus(Guid orderId, OrderStatus status);
        void Delete(Guid orderId);
    }
}
