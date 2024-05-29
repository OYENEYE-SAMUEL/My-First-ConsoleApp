using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmingApp.Models
{
    public class FarmManager : BaseEntity
    {
        public string UserEmail { get; set; } = default!;
        public string Qualification { get; set; } = default!;
        public int YearOfExperience { get; set; }
        public decimal Wallet { get; set; }

        public FarmManager(int id, string userEmail, string qualification, int yearOfExperience, decimal wallet) : base(id)
        {
            UserEmail = userEmail;
            Qualification = qualification;
            YearOfExperience = yearOfExperience;
            Wallet = wallet;
        }

        
    }
}