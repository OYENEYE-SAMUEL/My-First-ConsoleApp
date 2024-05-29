using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Models;

namespace FishFarmingApp.Manager.Interface
{
    public interface IFarmManagerManager
    {
        FarmManager Register(string email, int pin, string firstName, string lastName, string address, string phoneNumber, string roleName, Gender gender, string qualification, int yearOfExperience);
        FarmManager GetManager(string email);
        FarmManager GetAllManager();
        FarmManager Update (string email, string qualification, int yearOfExperience);
        FarmManager ManagerFundWallet(decimal wallet);
        FarmManager DeleteManager(string email);
        
    }
}