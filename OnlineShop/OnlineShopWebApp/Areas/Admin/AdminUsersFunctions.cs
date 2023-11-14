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
        public List<User> Read(string filePath)
        {
            var json = "";

            using (StreamReader reader = new StreamReader(filePath))
            {
                json = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<User>>(json);
        }
        public User TryGetById(Guid Id) => GetAll().FirstOrDefault(x => x.Id == Id);
        public List<User> GetAll()
        {
            var jsonFilePath = "wwwroot/users.json";
            return File.Exists(jsonFilePath) ? Read(jsonFilePath) : new List<User> { };
        }
        public void EditRole()
        {
        }
        public void Delete(Guid Id)
        {
            var users = GetAll();
            users.RemoveAt(users.FindIndex(x => x.Id == Id));
            SaveAll(users);
        }
        public void SaveAll(List<User> users)
        {
            var filePath = "wwwroot/users.json";
            string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }
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
    }
}
