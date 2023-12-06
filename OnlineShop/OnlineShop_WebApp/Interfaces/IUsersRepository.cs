using OnlineShop_WebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop_WebApp.Interfaces
{
    public interface IUsersRepository
    {
        void Add(UserViewModel user);
        List<UserViewModel> GetAll();
        UserViewModel TryGetById(Guid Id) ;
        UserViewModel TryGetByLogin(string Login);
    }
}
