using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSession
{
    public class Bike
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int PricePerDay { get; set; }
    }

    public class BikeUtility
    {
        public void AddBikeDetails(string model, string brand, int pricePerDay)
        {
            int key = Program.bikeDetails.Count + 1;
            Bike bike = new Bike
            {
                Model = model,
                Brand = brand,
                PricePerDay = pricePerDay,
            };
            Program.bikeDetails.Add(key, bike);
        }

        public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
        {
            SortedDictionary<string, List<Bike>> groupedBike = new();
            foreach (var item in Program.bikeDetails.Values)
            {
                if (!groupedBike.ContainsKey(item.Brand))
                {
                    groupedBike[item.Brand] = new List<Bike>();
                }
                groupedBike[item.Brand].Add(item);
            }
            return groupedBike;
        }

    }
    public class Program
    {
        public static SortedDictionary<int, Bike> bikeDetails = new();
        static void Main()
        {
            BikeUtility utility = new BikeUtility();
            while (true)
            {
                Console.WriteLine("1. Add Bike Details");
                Console.WriteLine("2. Group Bikes By Brand");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.WriteLine("Enter your choice");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Enter the model");
                    string model = Console.ReadLine();
                    Console.WriteLine("Enter the brand");
                    string brand = Console.ReadLine();
                    Console.WriteLine("Enter the price per day");
                    int pricePerDay = int.Parse(Console.ReadLine());
                    utility.AddBikeDetails(model, brand, pricePerDay);
                    Console.WriteLine("Bike details added successfully");
                }
                else if (choice == 2)
                {
                    SortedDictionary<string, List<Bike>> groupedBikes = utility.GroupBikesByBrand();
                    foreach (var item in groupedBikes)
                    {
                        Console.WriteLine(item.Key);
                        foreach (var item2 in item.Value)
                        {
                            
                            Console.WriteLine(item2.Model);
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 3)
                {
                    break;
                }
            }
        }
    }
}
