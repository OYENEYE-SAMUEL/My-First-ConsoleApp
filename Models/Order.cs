using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmingApp.Models
{
    public class Order : BaseEntity
    {
        public string CustomerTagNumber { get; set; } = default!;
        public bool IsDelivered { get; set; }
        public DateTime DateOrder { get; set; } = DateTime.Now;
        public Dictionary<string, int> OrderFish { get; set; } = new Dictionary<string, int>();
        public decimal TotalPrice { get; set; }

        public Order(int id, string customerTagNumber, DateTime dateOrder, Dictionary<string, int> orderFish, decimal totalPrice, bool isDelivered) : base(id)
        {
           
            CustomerTagNumber = customerTagNumber;
            DateOrder = dateOrder;
            OrderFish = orderFish;
            TotalPrice = totalPrice;
            IsDelivered = isDelivered;
        }
        

    }
}