using OnlineShop_WebApp.Interfaces;
using OnlineShop_WebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineShop_WebApp.Repositories
{
    public class InFileRolesRepository: IRolesRepository 
    {
        public List<Roles> roles = new List<Roles>() { };
        public InFileRolesRepository() {
            roles = LoadRolesFromFile();
        }

        public List<Roles> LoadRolesFromFile()
        {
            var filePath = "wwwroot/roles.txt";
            List<Roles> roles = new List<Roles>();

            if (File.Exists(filePath))
            {
                string[] roleLines = File.ReadAllLines(filePath);

                foreach (var roleLine in roleLines)
                {
                    roles.Add(new Roles { Name = roleLine });
                }
            }
            return roles;
        }
        public void Save(List<Roles> roles)
        {
            var filePath = "wwwroot/roles.txt";
            List<string> roleLines = new List<string>();
            foreach (var role in roles)
            {
                roleLines.Add(role.Name);
            }
            File.WriteAllLines(filePath, roleLines);
        }
        public List<Roles> GetAll()
        {
            return roles;
        }

        public void Add(Roles role)
        {
            roles.Add(role);
            Save(roles);
        }

        public void Delete(string name)
        {
            var role = roles.FirstOrDefault(x => x.Name == name);
            roles.Remove(role);
            Save(roles);
        }

    }
}
