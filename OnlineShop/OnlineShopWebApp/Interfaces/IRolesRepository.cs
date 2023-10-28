using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IRolesRepository
    {
        void Add(Roles role);
        void Delete(string name);
        List<Roles> GetAll();
    }
}
