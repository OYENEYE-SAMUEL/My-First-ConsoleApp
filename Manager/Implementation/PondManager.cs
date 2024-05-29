using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmingApp.Context;
using FishFarmingApp.Manager.Interface;
using FishFarmingApp.Models;

namespace FishFarmingApp.Manager.Implementation
{
    public class PondManager : IPondManager
    {
        public Pond Create(string name, string description, string pondSize)
        {
            var exists = IsExist(name);
            if (exists)
            {
                Console.WriteLine($"The {name} already exists");
                return null;
            }
            var id = FishFarming.ponds.Count + 1;
            var pondTagNum = GeneratePondTagNum(id);
            Pond pond = new Pond(id, name, description, pondTagNum, pondSize);
            FishFarming.ponds.Add(pond);
            Console.WriteLine("*************** Pond created Successfully *************");
            return pond;
        }

        private bool IsExist(string name)
        {
            foreach (var item in FishFarming.ponds)
            {
                if (item.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        private string GeneratePondTagNum(int id)
        {
            Random rand = new Random();
            return $"{rand.Next(20, 1000)}/{id}";
        }


        public List<Pond> GetAllPonds()
        {
            foreach (var item in FishFarming.ponds)
            {
                Console.WriteLine($"Pond id: {item.Id}\t Pond name: {item.Name}\t Pond description: {item.Description}\t Pond tag No: {item.PondTagNumber}\t Pond side: {item.PondSize}");
            }
            return null;
        }

        private Pond GetPond(string pondTagNum)
        {
            foreach (var item in FishFarming.ponds)
            {
                if (item.PondTagNumber == pondTagNum)
                {
                    return item;
                }
            }
            return null;
        }

        public Pond UpdatePond(string pondTagNum, string pondSize, string name, string description)
        {
            var pond = GetPond(pondTagNum);
            if (pond == null)
            {
                Console.WriteLine($"{pondTagNum} was not found");
            }
            pond.PondSize = pondSize;
            pond.Name = name;
            pond.Description = description;
            Console.WriteLine("============== Pond updated successfully ==============");
            return pond;
        }

        public Pond DeletePond(string pondTagNum)
        {
            var pond = GetPond(pondTagNum);
            if (pond == null)
            {
                Console.WriteLine("The pond does not exist");
            }
            FishFarming.ponds.Remove(pond);
            Console.WriteLine("============== Pond deleted successfully ==============");
            return pond;
        }


    }
}