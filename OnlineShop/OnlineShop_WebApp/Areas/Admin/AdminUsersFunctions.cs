using Newtonsoft.Json;
using OnlineShop_WebApp.Interfaces;
using OnlineShop_WebApp.Models;

namespace OnlineShop_WebApp.Areas.Admin
{
    public class AdminUsersFunctions : IAdminUsersFunctions
    {
        public List<UserViewModel> Read(string filePath)
        {
            var json = "";

            using (StreamReader reader = new StreamReader(filePath))
            {
                json = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<UserViewModel>>(json);
        }
        public UserViewModel TryGetById(Guid Id) => GetAll().FirstOrDefault(x => x.Id == Id);
        public List<UserViewModel> GetAll()
        {
            var jsonFilePath = "wwwroot/users.json";
            return File.Exists(jsonFilePath) ? Read(jsonFilePath) : new List<UserViewModel> { };
        }
        public void EditRole(UserViewModel user)
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
        public void SaveAll(List<UserViewModel> users)
        {
            var filePath = "wwwroot/users.json";
            string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }
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

        public void EditPassword(Guid Id, string password)
        {
            var users = GetAll();
            users[users.FindIndex(x => x.Id == Id)].Password = password;
            SaveAll(users);
        }
        public void Edit(UserViewModel user)
        {
            var users = GetAll();
            users[users.FindIndex(x => x.Id == user.Id)] = user;
            SaveAll(users);
        }
    }
}
