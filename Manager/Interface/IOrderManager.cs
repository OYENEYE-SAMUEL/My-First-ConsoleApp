using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Models;

namespace FishFarmingApp.Manager.Interface
{
    public interface IOrderManager
    {
        Order Make(Dictionary<string, int> orderedFishes, DateTime dateOrder);
        Order GetOrder(string customerTagNumber);
        List<Order> GetAllOrders();
        Order Delete(string customerTagNumber);

    }
}