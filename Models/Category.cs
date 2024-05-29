using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmingApp.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Period { get; set; } = default!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Category(int id, string name, string period, decimal price, int quantity) : base(id)
        {
            Name = name;
            Period = period;
            Price = price;
            Quantity = quantity;
        }

       



    }
}