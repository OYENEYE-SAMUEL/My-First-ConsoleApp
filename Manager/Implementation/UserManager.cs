using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Context;
using FishFarmingApp.Manager.Interface;
using FishFarmingApp.Models;

namespace FishFarmingApp.Manager.Implementation
{
    public class UserManager : IUserManager
    {
        public static User LoginUser;
        public User CurrentUser()
        {
            return LoginUser;
        }

        public User Login(string email, int pin)
        {
            var user = GetUserByEmail(email);
            if (user != null && user.Pin == pin)
            {
                LoginUser = user;
                return user;
            }
            else
            {
                 Console.WriteLine("Oooops... Invalid Email or Pin");
            }
           
            return null;
        }

        public List<User> GetAllUser()
        {
            return FishFarming.users;
        }

        public User GetUser(int id)
        {
            foreach (var item in FishFarming.users)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public User GetUserByEmail(string email)
        {
            foreach (var item in FishFarming.users)
            {
                if (item.Email == email)
                {
                    return item;
                }
            }
            return null;
        }


        // public User DeleteUser(int id)
        // {
        //     var user = GetUser(id);
        //     if (user == null)
        //     {
        //         Console.WriteLine("This user does not exist in the database");
        //     }
        //     FishFarming.users.Remove(user);
        //     return user;
        // }


    }
}