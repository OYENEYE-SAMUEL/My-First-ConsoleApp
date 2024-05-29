using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmingApp.Models
{
    public class Pond : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; } 
        public string PondTagNumber { get; set; } = default!;
        public string PondSize { get; set; } = default!;

        public Pond(int id, string name, string description, string pondTagNumber, string pondSize) : base(id)
        {
            Name = name;
            Description = description;
            PondTagNumber = pondTagNumber;
            PondSize = pondSize;
        }

    }
}