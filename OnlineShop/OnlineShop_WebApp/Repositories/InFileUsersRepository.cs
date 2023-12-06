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
        public List<User> users = new List<User>();

        public void Add(User user)
        {
            user.Id = Guid.NewGuid();
            string filePath = "wwwroot/users.json";

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var existingUsers = JsonConvert.DeserializeObject<List<User>>(json);
                if (existingUsers == null)
                {
                    existingUsers = new List<User> { user };
                }
                existingUsers.Add(user);
                string updatedJson = JsonConvert.SerializeObject(existingUsers, Formatting.Indented);
                File.WriteAllText(filePath, updatedJson);
            }
        }
        public User TryGetById(Guid Id) => GetAll().FirstOrDefault(x => x.Id == Id);
        public User TryGetByLogin(string Login) => GetAll().FirstOrDefault(x => x.Login == Login);

        private List<User> Read(string filePath)
        {
            var json = "";

            using (StreamReader reader = new StreamReader(filePath))
            {
                json = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<User>>(json);
        }
        public List<User> GetAll()
        {
            var jsonFilePath = "wwwroot/users.json";
            return File.Exists(jsonFilePath) ? Read(jsonFilePath) : new List<User> { };
        }



    }
}
