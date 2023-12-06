using OnlineShop_WebApp.Models;
using System.Collections.Generic;

namespace OnlineShop_WebApp.Interfaces
{
    public interface IRolesRepository
    {
        void Add(Roles role);
        void Delete(string name);
        List<Roles> GetAll();
    }
}
