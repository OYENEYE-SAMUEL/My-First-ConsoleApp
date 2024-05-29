using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Models;

namespace FishFarmingApp.Manager.Interface
{
    public interface ICategoryManager
    {
        Category Create(string name, string period, decimal price, int quantity);
        Category Get(int id);
        Category GetCategory(string name);
        List<Category> GetAll();
        Category Update(int id, decimal price, int quantity);
        Category DeleteCategory(int id);

    }
}