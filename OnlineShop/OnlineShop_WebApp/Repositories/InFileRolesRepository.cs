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
        public List<RoleViewModel> roles = new List<RoleViewModel>() { };
        public InFileRolesRepository() {
            roles = LoadRolesFromFile();
        }

        public List<RoleViewModel> LoadRolesFromFile()
        {
            var filePath = "wwwroot/roles.txt";
            List<RoleViewModel> roles = new List<RoleViewModel>();

            if (File.Exists(filePath))
            {
                string[] roleLines = File.ReadAllLines(filePath);

                foreach (var roleLine in roleLines)
                {
                    roles.Add(new RoleViewModel { Name = roleLine });
                }
            }
            return roles;
        }
        public void Save(List<RoleViewModel> roles)
        {
            var filePath = "wwwroot/roles.txt";
            List<string> roleLines = new List<string>();
            foreach (var role in roles)
            {
                roleLines.Add(role.Name);
            }
            File.WriteAllLines(filePath, roleLines);
        }
        public List<RoleViewModel> GetAll()
        {
            return roles;
        }

        public void Add(RoleViewModel role)
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
