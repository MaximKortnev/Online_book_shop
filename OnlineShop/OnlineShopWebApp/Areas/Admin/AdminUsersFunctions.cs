using Newtonsoft.Json;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin
{
    public class AdminUsersFunctions : IAdminUsersFunctions
    {
        private readonly IUsersRepository usersRepository;
        public AdminUsersFunctions(IUsersRepository usersRepository)
        {
           this.usersRepository = usersRepository;
        }
        public void EditRole(User user)
        {
            var users = usersRepository.GetAll();
            users[users.FindIndex(x => x.Id == user.Id)] = user;
            SaveAll(users);
        }
        public void Delete(Guid Id)
        {
            var users = usersRepository.GetAll();
            users.RemoveAt(users.FindIndex(x => x.Id == Id));
            SaveAll(users);
        }
        public void SaveAll(List<User> users)
        {
            var filePath = "wwwroot/users.json";
            string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }
    }
}
