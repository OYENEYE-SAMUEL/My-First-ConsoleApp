using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Models;

namespace FishFarmingApp.Manager.Interface
{
    public interface IRoleManager
    {
         Role Create(string name, string description);
         Role Get(int id);
         List<Role>GetAllRole();
         
    }
}