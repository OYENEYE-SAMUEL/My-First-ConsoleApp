using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Context;
using FishFarmingApp.Manager.Implementation;
using FishFarmingApp.Models;

namespace FishFarmingApp.Menu
{
    public class MainMenu
    {
        UserManager userManager = new UserManager();
        AdminBoard adminBoard = new AdminBoard();
        CustomerBoard customerBoard = new CustomerBoard();
        FarmManagerBoard farmManagerBoard = new FarmManagerBoard();
        
        public void Menu()
        {
            bool isContinue = true;
            while (isContinue)
            {
                 Console.WriteLine("============== Welcome to Sammy Aquacultures ===================");
            Console.WriteLine("Enter 1 to Register\n Enter 2 to Login\n Enter 3 to Exit");
            int input = int.Parse(Console.ReadLine());

            if (input == 1)
            {
                customerBoard.RegisterCustomerMenu();
            }
            else if (input == 2)
            {
                LoginMenu();
            }
            else if (input == 3)
            {
                 Console.WriteLine("================== Exit successfully ===================");
                Environment.Exit(0);
            }
            else
            {
               Console.WriteLine("Invalid input select from the options");
               Menu();
            }
        }

        }

         public void LoginMenu()

        {

            Console.WriteLine("Enter your Email");
            string email = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Enter your Pin");
            int pin = int.Parse(Console.ReadLine());
            var userInput = userManager.Login(email, pin);
            if (userInput != null)
            {
                if (userInput.RoleName == "Admin")
                {
                    adminBoard.AdminMenu();
                }
                else if (userInput.RoleName == "Customer")
                {
                    customerBoard.CustomerMenu();
                }
                else if (userInput.RoleName == "Manager")
                {
                    farmManagerBoard.FarmManagerMenu();
                }
                else
                {
                    Console.WriteLine("Invalid role name!");
                }
            }
        
 
            }

    }
}