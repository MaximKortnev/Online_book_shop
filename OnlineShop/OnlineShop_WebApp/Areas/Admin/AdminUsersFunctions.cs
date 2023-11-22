using Newtonsoft.Json;
using OnlineShop_WebApp.Interfaces;
using OnlineShop_WebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineShop_WebApp.Areas.Admin
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
        public void EditRole(User user)
        {
            var users = GetAll();
            users[users.FindIndex(x => x.Id == user.Id)] = user;
            SaveAll(users);
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

        public void EditPassword(Guid Id, string password)
        {
            var users = GetAll();
            users[users.FindIndex(x => x.Id == Id)].Password = password;
            SaveAll(users);
        }
        public void Edit(User user)
        {
            var users = GetAll();
            users[users.FindIndex(x => x.Id == user.Id)] = user;
            SaveAll(users);
        }
    }
}
