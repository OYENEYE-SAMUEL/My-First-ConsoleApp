using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Context;
using FishFarmingApp.Manager.Interface;
using FishFarmingApp.Menu;
using FishFarmingApp.Models;

namespace FishFarmingApp.Manager.Implementation
{
    public class OrderManager : IOrderManager
    {
        CustomerManager customerManager = new CustomerManager();
        CategoryManager categoryManager = new CategoryManager();
        FarmManagerManager farmManagerManager = new FarmManagerManager();

        public Order Make(Dictionary<string, int> orderedFishes, DateTime dateOrder)
        {

            //Category category = null;
            decimal newTotalPrice = 0;
            foreach (var fish in orderedFishes)
            {
                var category = categoryManager.GetCategory(fish.Key);
                if (category == null)
                {
                    Console.WriteLine("This type of fish is not avaliable");
                    return null;
                }

                int quant = fish.Value;
                newTotalPrice += category.Price * quant;
            }


            bool isDelivered = true;
            var id = FishFarming.orderFish.Count + 1;
            var customer = customerManager.GetCustomer(UserManager.LoginUser.Email);
            var order = new Order(id, customer.TagNumber, dateOrder, orderedFishes, newTotalPrice, isDelivered);
            FishFarming.orderFish.Add(order);
            foreach (var fish in orderedFishes)
            {
                var category = categoryManager.GetCategory(fish.Key);
                if (category.Quantity == 0 || category.Quantity < fish.Value)
                {
                    Console.WriteLine($"Ooops... The number quantity is not available, Kindly order in this quantity range {fish.Value}");
                }
                int reduceQuan = fish.Value;
                category.Quantity -= reduceQuan;
            }
            if (customer.Wallet == 0 || customer.Wallet < order.TotalPrice)
            {
                Console.WriteLine("Insufficient balance! kindly fund your wallet");
                isDelivered = false;
            }
            else
            {
                var manager = farmManagerManager.GetManager("sam@gmail.com");
                customer.Wallet -= order.TotalPrice;
                manager.Wallet += order.TotalPrice;

                Console.WriteLine("============== ordered successfully =================");
                isDelivered = true;
                return order;
            }
            return null;

        }




        // public Order Make(Dictionary<string, int> orderedFishes, DateTime dateOrder)
        // {
        //     double newTotalPrice = 0;
        //     bool allFishesAvailable = true;

        //     foreach (var fish in orderedFishes)
        //     {
        //         var category = categoryManager.GetCategory(fish.Key);
        //         if (category == null)
        //         {
        //             Console.WriteLine($"This type of fish '{fish.Key}' is not available.");
        //             allFishesAvailable = false;
        //             continue;  // Skip this fish as it's not available
        //         }
        //         newTotalPrice += category.Price; // Assuming fish.Value represents quantity
        //     }

        //     if (!allFishesAvailable)
        //     {
        //         Console.WriteLine("Some fishes are not available. Order was not placed.");
        //         return null;
        //     }

        //     var id = FishFarming.orderFish.Count + 1;
        //     var customer = customerManager.GetCustomer(UserManager.LoginUser.Email);
        //     var order = new Order(id, customer.TagNumber, dateOrder, orderedFishes, newTotalPrice);
        //     FishFarming.orderFish.Add(order);

        //     Console.WriteLine("============== Ordered successfully =================");
        //     return order;
        // }


        public List<Order> GetAllOrders()
        {
            foreach (var item in FishFarming.orderFish)
            {
                Console.WriteLine($"Customer Tag No: {item.CustomerTagNumber}\n Order Id: {item.Id}\n");
                foreach (var order in item.OrderFish)
                {
                    Console.WriteLine($"Items Order:{order.Key} {order.Value}\n");
                }
                Console.WriteLine($"Total Price: {item.TotalPrice}\n Date order: {item.DateOrder} Order status: {item.IsDelivered}");
            }
            return null;
        }

        public void ViewOrderHistory()
        {

            foreach (var item in FishFarming.orderFish)
            {
                foreach (var order in item.OrderFish)
                {
                    Console.WriteLine($"Your order: {order.Key} {order.Value}");
                }
                Console.Write($"Date Order: {item.DateOrder}\n Total price: {item.TotalPrice}\n Order status: {item.IsDelivered}");

            }

        }

        public Order GetOrder(string customerTagNumber)
        {
            foreach (var item in FishFarming.orderFish)
            {
                if (item.CustomerTagNumber == customerTagNumber)
                {
                    return item;
                }
            }
            return null;
        }

        public Order Delete(string customerTagNumber)
        {
            var order = GetOrder(customerTagNumber);
            if (order == null)
            {
                Console.WriteLine("Order does not exist presently");
            }
            FishFarming.orderFish.Remove(order);
            Console.WriteLine("============ Deleted sucesfully ==========");
            return order;
        }


    }

}