using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmingApp.Models
{
    public class Role : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;

        public Role(int id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }

       
    }
}