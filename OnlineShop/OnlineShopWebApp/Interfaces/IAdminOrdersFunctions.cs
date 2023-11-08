﻿using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface IAdminOrdersFunctions
    {
        OrderData TryGetById(Guid Id);
        public void EditStatus(Guid orderId, string status);
        public void Delete(Guid orderId);
    }
}
