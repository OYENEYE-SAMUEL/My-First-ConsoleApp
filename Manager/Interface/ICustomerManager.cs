using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Models;

namespace FishFarmingApp.Manager.Interface
{
    public interface ICustomerManager
    {
        Customer Register(string email, int pin, string firstName, string lastName, string address, string phoneNumber, Gender gender, decimal wallet);
        Customer GetCustomer(string email);
        Customer GetCustomerByTagNumber(string tagNumber);
        List<Customer> GetAllCustomers();
        Customer CustomerFundWallet(decimal wallet);
        Customer DeleteCustomer(string tagNumber);
    }
}