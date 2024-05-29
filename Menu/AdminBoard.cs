using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Manager;
using FishFarmingApp.Manager.Implementation;

namespace FishFarmingApp.Menu
{
    public class AdminBoard
    {
        FarmManagerBoard farmManagerBoard = new FarmManagerBoard();
        FarmManagerManager farmManagerManager = new FarmManagerManager();
        CustomerManager customerManager = new CustomerManager();
        OrderManager orderManager = new OrderManager();
       
        public void AdminMenu()
        {

            bool isContinue = true;
            while (isContinue)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("================ Welcome to Admin Dashboard ===================");
                Console.WriteLine("1: Register Manager\n 2: View all Manager");
                Console.WriteLine("3: Remove Manager");
                Console.WriteLine("4: View all Customers");
                Console.WriteLine("5: Remove Customer");
                Console.WriteLine("6: View all orders");
                Console.WriteLine("7: to Main Menu");
                Console.WriteLine("0: Logout");
                Console.WriteLine("====================\n =============");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        farmManagerBoard.RegisterFarmManagerMenu();
                        Console.WriteLine();
                        AdminMenu();
                        break;

                    case 2:
                        farmManagerManager.GetAllManager();
                        Console.WriteLine();
                        AdminMenu();
                        break;

                    case 3:
                        Console.WriteLine("Enter Manager's email");
                        string email = Console.ReadLine();
                        farmManagerManager.DeleteManager(email);
                        Console.WriteLine("================== Deleted successfully ============= ");
                        Console.WriteLine();
                        AdminMenu();
                        break;

                    case 4:
                        customerManager.GetAllCustomers();
                        Console.WriteLine();
                        AdminMenu();
                        break;

                    case 5:

                        Console.WriteLine("Kindly provide the Customer's tag number: ");
                        string tagNumber = Console.ReadLine();
                        customerManager.DeleteCustomer(tagNumber);
                     
                        Console.WriteLine();

                        AdminMenu();
                        break;

                    case 6:
                        orderManager.GetAllOrders();
                        Console.WriteLine();
                        AdminMenu();
                        break;

                    case 7:
                     MainMenu mainMenu = new MainMenu();
                        mainMenu.Menu();
                        break;

                    case 8:
                        Console.WriteLine("Logged out successfully");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid input, kindly select from the options");
                        break;
                }
            }
           
        }
    }
}