using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IAdminUsersFunctions
    {
        void EditRole(User user);
        void Delete(Guid Id);
        void SaveAll(List<User> users);
    }
}
