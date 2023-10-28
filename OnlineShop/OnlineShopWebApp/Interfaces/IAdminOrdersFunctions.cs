using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface IAdminOrdersFunctions
    {
        OrderData TryGetById(Guid Id);
        public void EditStatus(Guid orderId, string status);
        public void Delete(Guid orderId);
        public void SaveAll(List<OrderData> orders);
    }
}
