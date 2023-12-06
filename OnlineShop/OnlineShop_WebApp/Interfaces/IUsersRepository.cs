using OnlineShop_WebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop_WebApp.Interfaces
{
    public interface IUsersRepository
    {
        void Add(User user);
        List<User> GetAll();
        User TryGetById(Guid Id) ;
        User TryGetByLogin(string Login);
    }
}
