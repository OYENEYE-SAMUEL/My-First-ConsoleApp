using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Context;

namespace FishFarmingApp.Models
{
    public abstract class BaseEntity 
    {
        public int Id { get; set; }
        
        public BaseEntity(int id)
        {
            Id = id;
        }

    }
}