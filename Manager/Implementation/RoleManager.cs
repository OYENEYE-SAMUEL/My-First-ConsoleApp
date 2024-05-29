using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Context;
using FishFarmingApp.Manager.Interface;
using FishFarmingApp.Models;

namespace FishFarmingApp.Manager.Implementation
{
    public class RoleManager : IRoleManager
    {
        public Role Create(string name, string description)
        {
            var exists = IsExist(name);
            if (exists)
            {
                Console.WriteLine($"The role {name} already exist");
                return null;
            }
            var id = FishFarming.users.Count + 1;
            Role role = new Role(id, name, description);
            FishFarming.roles.Add(role);
            Console.WriteLine("created successfully");
            return role;
        }

        private bool IsExist(string name)
    {
        foreach (var item in FishFarming.roles)
        {
            if (item.Name == name)
            {
                return true;
            }
        }
        return false;
    }

        public Role Get(int id)
        {
           foreach (var item in FishFarming.roles)
           {
             if (item.Id == id)
             {
                return item;
             }
           }
           return null;
        }

        public List<Role> GetAllRole()
        {
          foreach (var item in FishFarming.roles)
          {
            Console.WriteLine($"Role id: {item.Id}\t Role name: {item.Name}\t Role description: {item.Description}");
          }
          return null;
        }
    }
}