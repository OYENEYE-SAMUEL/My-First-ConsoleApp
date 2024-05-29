using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Manager.Implementation;
using FishFarmingApp.Manager.Interface;
using FishFarmingApp.Models;

namespace FishFarmingApp.Menu
{
    public class CustomerBoard
    {
        CustomerManager customerManager = new CustomerManager();
        OrderManager orderManager = new OrderManager();
        CategoryManager categoryManager = new CategoryManager();



        public void CustomerMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("============== Welcome to Customer DashBoard =====================");
            Console.WriteLine("1: View Profile\n 2: View wallet balance");
            Console.WriteLine("3: Fund Wallet");
            Console.WriteLine("4: View all category of fish");
            Console.WriteLine("5: Make order");
            Console.WriteLine(" 6: View order history");
            Console.WriteLine("7: Delete account ");
            Console.WriteLine("99: To Menu");
            Console.WriteLine("0: to Logout");

            Console.WriteLine("==================\n ==========");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                customerManager.GetCustomerProfile();
                Console.WriteLine();
                CustomerMenu();

            }
            else if (input == 2)
            {

                customerManager.ViewCustomerWallet();
                CustomerMenu();

            }
            else if (input == 3)
            {
                Console.WriteLine("Input the amount to add to wallet: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                customerManager.CustomerFundWallet(amount);
                Console.WriteLine();
                CustomerMenu();

            }
            else if (input == 4)
            {

                categoryManager.CustomerToViewCategory();
                Console.WriteLine();
                CustomerMenu();
            }
            else if (input == 5)
            {
                Console.WriteLine("Enter the type of fish to be ordered: ");
                string fishType = Console.ReadLine();
                Console.WriteLine("How many do you want: ");
                int number = int.Parse(Console.ReadLine());
                var orders = new Dictionary<string, int>();
                orders.Add(fishType, number);
                var order = new OrderManager();
                order.Make(orders, DateTime.Now);

                Console.WriteLine();
                CustomerMenu();

            }
            else if (input == 6)
            {
                orderManager.ViewOrderHistory();
                Console.WriteLine();
                CustomerMenu();

            }
            else if (input == 7)
            {
                Console.WriteLine("Enter your tag number to delete your account: ");
                string tagNumber = Console.ReadLine();
                orderManager.Delete(tagNumber);
                Console.WriteLine();
                MainMenu mainMenu = new MainMenu();
                mainMenu.Menu();
            }
            else if (input == 99)
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Menu();
            }
            else if (input == 0)
            {
                Console.WriteLine("*********** Logout successfully ************");
                Environment.Exit(0);
            }

            else
            {
                Console.WriteLine("Invalid input, kindly select from the options");
                CustomerMenu();
            }
        }

        public void RegisterCustomerMenu()
        {
            try
            {
                Console.WriteLine("============= Welcome to Customer Registration, kindly make use of valid info ==============");
                Console.WriteLine("Enter your email address: ");
                string email = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Kindly make use of number.....Create your new pin: ");
                string pin = Console.ReadLine();

                var toSpring = pin.ToString();
                var numbers = "1234567890";
                foreach (var item in toSpring)
                {
                    if (!numbers.Contains(item))
                    {
                        Console.WriteLine("Invalid input. Please use number for your pin");
                        Console.WriteLine();
                        RegisterCustomerMenu();
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Enter your First Name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter your Last Name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter your address: ");
                string address = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter your phone Number: ");
                string phoneNumber = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter your Gender\n press 1 for male\n press 2 for female");
                Gender gender = (Gender)int.Parse(Console.ReadLine());
                Console.WriteLine();
                var cust = customerManager.Register(email, int.Parse(pin), firstName, lastName, address, phoneNumber, gender, 0);
                Console.WriteLine();
                Console.WriteLine($"========================= Congratulations! You have successfully registered \n ==============");
                MainMenu mainMenu = new MainMenu();
                mainMenu.LoginMenu();
            }
            catch (Exception)
            {

                Console.WriteLine("Ooopps... Invalid access");
                RegisterCustomerMenu();

            }

        }
    }
}