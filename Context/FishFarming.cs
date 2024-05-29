using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Models;

namespace FishFarmingApp.Context
{
    public class FishFarming
    {
        public static List<User> users= new List<User>()
        {new User (1, "admin@gmail.com", 1234,"Samuel", "Oyeneye", "Abeokuta", "08132590745", "Admin", Gender.Male)};
        

        public static List<Pond> ponds= new List<Pond>();
        public static List<Order> orderFish= new List<Order>();
        public static List<Role> roles = new List<Role>();
        public static List<Customer> customers= new List<Customer>();
        public static List<Category> categories= new List<Category>();
        public static List<FarmManager> farmManagers = new List<FarmManager>();
       
    }
}