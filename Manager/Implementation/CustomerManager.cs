using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Context;
using FishFarmingApp.Manager.Interface;
using FishFarmingApp.Models;

namespace FishFarmingApp.Manager.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        
        public Customer Register(string email, int pin, string firstName, string lastName, string address, string phoneNumber, Gender gender, decimal wallet)
        {
            var exists = IsExist(email);
            if (exists)
            {
                Console.WriteLine($"Oooops... Customer  with this mail {email} already exist");
                return null;
            }
            var id = FishFarming.users.Count + 1;
            var user = new User(id, email, pin, firstName, lastName, address, phoneNumber, "Customer", gender);
            FishFarming.users.Add(user);


            id = FishFarming.customers.Count + 1;
            var customerTagNumber = GenerateCustomerTagNumber(firstName, lastName);
            var customer = new Customer(id, email, customerTagNumber, 0);
            FishFarming.customers.Add(customer);
            return customer;


        }

        private bool IsExist(string email)
        {
            foreach (var item in FishFarming.customers)
            {
                if (item.UserEmail == email)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Customer> GetAllCustomers()
        {
            foreach (var item in FishFarming.customers)
            {
                Console.WriteLine($"Id:{item.Id}\t Email:{item.UserEmail}\t tag No:{item.TagNumber}");
            }
            return null;
        }

        private string GenerateCustomerTagNumber(string firstName, string lastName)
        {
            Random rand = new Random();

            return $"FM/{Upper(firstName[0])}/{Upper(lastName[0])}/{rand.Next(500, 700000)}";

        }
        private string Upper(char a)
        {
            return a.ToString().ToUpper();
        }

        public Customer GetCustomer(string email)
        {
            foreach (var item in FishFarming.customers)
            {
                if (item.UserEmail == email)
                {
                    return item;
                }
            }
            return null;
        }

        public Customer GetCustomerByTagNumber(string customerTagNumber)
        {
            foreach (var item in FishFarming.customers)
            {
                if (item.TagNumber == customerTagNumber)
                {
                   return item;
                }
            }
            return null;
        }

        public void GetCustomerProfile()
        {
            var user = UserManager.LoginUser;
            var cust = GetCustomer(user.Email);
            Console.WriteLine($" Name: {user.LastName} {user.FirstName}\n Email: {user.Email}\n Address: {user.Address}\n Phoone No: {user.PhoneNumber}\n Gender: {user.Gender}\n Tag No: {cust.TagNumber}");
        }



        // public void AccountDeduction()
        // {
        //     OrderManager orderManager = new OrderManager();
        //     var customer = GetCustomer(UserManager.LoginUser.Email);
        //     var order = orderManager.GetOrder(customer.TagNumber);
        //     customer.Wallet -= order.TotalPrice;
        // }
        public Customer CustomerFundWallet(decimal amount)
        {
            var customer = GetCustomer(UserManager.LoginUser.Email);
            customer.Wallet += amount;
            Console.WriteLine("========== wallet is fund successfully ==============");
            return customer;
        }

        public void ViewCustomerWallet()
        {
            var wallet = GetCustomer(UserManager.LoginUser.Email);
            Console.WriteLine($"Wallet Balance: {wallet.Wallet}");
        }

        public Customer DeleteCustomer(string customerTagNumber)
        {
            var customer = GetCustomerByTagNumber(customerTagNumber);
            
            FishFarming.customers.Remove(customer);
            Console.WriteLine("*********** Customer deleted successfully ****************");
            return customer;
        }


    }
}