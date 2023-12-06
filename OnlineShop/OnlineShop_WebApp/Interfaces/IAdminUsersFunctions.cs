using OnlineShop_WebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop_WebApp.Interfaces
{
    public interface IAdminUsersFunctions
    {
        List<UserViewModel> Read(string filePath);
        UserViewModel TryGetById(Guid Id);
        List<UserViewModel> GetAll();
        void EditRole(UserViewModel user);
        void Delete(Guid Id);
        void SaveAll(List<UserViewModel> users);
        void Add(UserViewModel user);
        void EditPassword(Guid Id, string password);
        void Edit(UserViewModel user);
    }
}
