using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IUsersRepository
    {
        void Add(User user);
        List<User> GetAll();
    }
}
