using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Models;

namespace FishFarmingApp.Manager.Interface
{
    public interface IUserManager
    {
        User Login(string email, int pin);
        User CurrentUser();
        User GetUser(int id);
        User GetUserByEmail(string email);
        List<User> GetAllUser();
        // User DeleteUser(int id);

    }
}