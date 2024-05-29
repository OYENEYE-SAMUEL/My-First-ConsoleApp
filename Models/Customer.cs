using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmingApp.Models
{
    public class Customer : BaseEntity
    {
        public string UserEmail { get; set; } = default!;
        public string TagNumber { get; set; } = default!;
        public decimal Wallet { get; set; }

        public Customer(int id, string userEmail, string tagNumber, decimal wallet) : base(id)
        {
            UserEmail = userEmail;
            TagNumber = tagNumber;
            Wallet = wallet;
        }
       
  
    }
}