using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Models;

namespace FishFarmingApp.Manager.Interface
{
    public interface IPondManager
    {
         Pond Create(string name, string description, string pondSize);
         List<Pond> GetAllPonds();
         Pond UpdatePond(string pondTagNumber, string pondSize, string name, string description);
         Pond DeletePond(string pondTagNumber);

    }
}