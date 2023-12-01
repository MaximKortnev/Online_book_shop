using OnlineShop_WebApp.Models;
using System.Collections.Generic;

namespace OnlineShop_WebApp.Interfaces
{
    public interface IRolesRepository
    {
        void Add(RoleViewModel role);
        void Delete(string name);
        List<RoleViewModel> GetAll();
    }
}
