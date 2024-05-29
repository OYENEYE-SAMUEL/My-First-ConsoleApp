using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FishFarmingApp.Context;
using FishFarmingApp.Manager.Interface;
using FishFarmingApp.Models;

namespace FishFarmingApp.Manager.Implementation
{
    public class CategoryManager : ICategoryManager
    {
        public Category Create(string name, string period, decimal price, int quantity)
        {
           var exists = IsExist(name);
           if (exists)
           {
                Console.WriteLine($"The category {name} already exist");
                return null;
           }
          
          var id = FishFarming.categories.Count + 1;
           var category = new Category(id, name, period, price, quantity);
           FishFarming.categories.Add(category);
            Console.WriteLine("========== You have successfully create fish category ==============");
           return category;
        }

        private bool IsExist(string name)
        {
            foreach (var item in FishFarming.categories)
            {
                if (item.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public Category Get(int id)
        {
            foreach (var item in FishFarming.categories)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public void CustomerToViewCategory()
        {
           foreach (var item in FishFarming.categories)
           {
             Console.WriteLine($"Id: {item.Id}\t Name: {item.Name}\t Period {item.Period}\t Price: {item.Price}\t Quantity: {item.Quantity}");
           }
        }

        public List<Category> GetAll()
        {
            foreach (var item in FishFarming.categories)
            {
                Console.WriteLine($"Id: {item.Id}\t Name: {item.Name}\t Period: {item.Period}\t Price: {item.Price}\t Quantity: {item.Quantity}");
            }
            return null;
        }

        public Category GetCategory(string name)
        {
           
           foreach (var item in FishFarming.categories)
           {
                if(item.Name == name)
                {
                    return item;
                }

                
           }
           return null;
        }

         public Category Update(int id, decimal price, int quantity)
        {
            var category = Get(id);
            if (category == null)
            {
                Console.WriteLine("Category not found!");
                return null;
            }
            category.Price = price;
            category.Quantity += quantity;
             Console.WriteLine("************* Fish type updated Successfully *************");
            return category;
        }

         public Category DeleteCategory(int id)
        {
           var category = Get(id);
           if (category == null)
           {
                Console.WriteLine("Category does not exist");
           }
           FishFarming.categories.Remove(category);
           Console.WriteLine("--------------- Deleted successfully ----------");
           return category;
        }

       
    }
}