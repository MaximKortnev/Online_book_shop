using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IAdminUsersFunctions
    {
        List<User> Read(string filePath);
        User TryGetById(Guid Id);
        List<User> GetAll();
        void EditRole();
        void Delete(Guid Id);
        void SaveAll(List<User> users);
        void Add(User user);
    }
}
