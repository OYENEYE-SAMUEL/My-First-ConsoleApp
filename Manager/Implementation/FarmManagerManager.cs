using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FishFarmingApp.Context;
using FishFarmingApp.Manager.Implementation;
using FishFarmingApp.Manager.Interface;
using FishFarmingApp.Models;

namespace FishFarmingApp.Manager
{
    public class FarmManagerManager : IFarmManagerManager
    {
        UserManager userManager = new UserManager();

        public FarmManager Register(string email, int pin, string firstName, string lastName, string address, string phoneNumber, string roleName, Gender gender, string qualification, int yearOfExperience)
        {
            var exists = IsExist(email);
            if (exists)
            {
                Console.WriteLine($"This {email} already exist in the database");
                return null;
            };
            var id = FishFarming.users.Count + 1;
            var user = new User(id, email, pin, firstName, lastName, address, phoneNumber, roleName, gender);
            FishFarming.users.Add(user);
           
            
            id = FishFarming.farmManagers.Count + 1;
            var  farmManager = new FarmManager(id, email, qualification, yearOfExperience, 0);
            FishFarming.farmManagers.Add(farmManager);
            return farmManager;
            
        }

        private bool IsExist(string email)
        {
            foreach (var item in FishFarming.farmManagers)
            {
                if (item.UserEmail == email)
                {
                    return true;
                }
            }
            return false;
        }

        public FarmManager GetAllManager()
        {
            foreach (var item in FishFarming.farmManagers)
            {
                Console.WriteLine($"Info: Id: {item.Id}, Qualification: {item.Qualification}, Y.O.E: {item.YearOfExperience}, Email: {item.UserEmail}");
            }
            return null;
            
        }

        public FarmManager GetManager(string email)
        {
            foreach (var item in FishFarming.farmManagers)
            {
                if (item.UserEmail == email)
                {
                    return item;
                }
            }
            return null;
        }

         public void GetManagerProfile()
        {
         
          var user = UserManager.LoginUser;
          var manager = GetManager(user.Email); 
          Console.WriteLine($"Name: {user.LastName} {user.FirstName}\n Email: {user.Email}\n Phone No: {user.PhoneNumber}\n Gender: {user.Gender}\n Resident Add: {user.Address}\n Id: {user.Id}\n Qualification: {manager.Qualification}\n Y.O.E: {manager.YearOfExperience}");
          
        }

        public FarmManager Update(string email, string qualification, int yearOfExperience)
        {
            var manager = GetManager(email);
            if (manager == null)
            {
                Console.WriteLine($"{email} was not found");
            }
            manager.Qualification = qualification;
            manager.YearOfExperience = yearOfExperience;
            return manager;
        }

        public FarmManager ManagerFundWallet(decimal amount)
        {
            var manager = GetManager(UserManager.LoginUser.Email);

            manager.Wallet += amount;
            Console.WriteLine("========== wallet is fund successfully ==============");
            return manager;
        }

        public void ViewWalletBalance()
        {
            var manager = GetManager(UserManager.LoginUser.Email);
            Console.WriteLine($"Manager's Wallet Balance: {manager.Wallet}");
        }

        public FarmManager DeleteManager(string email)
        {
            var manager = GetManager(email);
            if (manager == null)
            {
                Console.WriteLine($"{email} was not found");
                return null;
            }
            FishFarming.farmManagers.Remove(manager);
            return manager;
        }

       
    }
}