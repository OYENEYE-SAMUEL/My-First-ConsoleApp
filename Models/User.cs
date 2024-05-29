using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using FishFarmingApp.Context;

namespace FishFarmingApp.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = default!;
        public int Pin { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string RoleName { get; set; } = default!;
        public Gender Gender{ get; set; } = default!;
        
        // public static string CurrentUser;

        public User(int id, string email, int pin, string firstName, string lastName, string address, string phoneNumber, string roleName, Gender gender) : base(id)
        {
            Email = email;
            Pin = pin;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            RoleName = roleName;
            Gender = gender;
        }


    }
}