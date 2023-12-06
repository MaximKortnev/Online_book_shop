using Newtonsoft.Json;
using OnlineShop_WebApp.Interfaces;
using OnlineShop_WebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineShop_WebApp.Repositories
{
    public class InFileUsersRepository : IUsersRepository
    {
        public List<UserViewModel> users = new List<UserViewModel>();

        public void Add(UserViewModel user)
        {
            user.Id = Guid.NewGuid();
            string filePath = "wwwroot/users.json";

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var existingUsers = JsonConvert.DeserializeObject<List<UserViewModel>>(json);
                if (existingUsers == null)
                {
                    existingUsers = new List<UserViewModel> { user };
                }
                existingUsers.Add(user);
                string updatedJson = JsonConvert.SerializeObject(existingUsers, Formatting.Indented);
                File.WriteAllText(filePath, updatedJson);
            }
        }
        public UserViewModel TryGetById(Guid Id) => GetAll().FirstOrDefault(x => x.Id == Id);
        public UserViewModel TryGetByLogin(string Login) => GetAll().FirstOrDefault(x => x.Login == Login);

        private List<UserViewModel> Read(string filePath)
        {
            var json = "";

            using (StreamReader reader = new StreamReader(filePath))
            {
                json = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<UserViewModel>>(json);
        }
        public List<UserViewModel> GetAll()
        {
            var jsonFilePath = "wwwroot/users.json";
            return File.Exists(jsonFilePath) ? Read(jsonFilePath) : new List<UserViewModel> { };
        }



    }
}
