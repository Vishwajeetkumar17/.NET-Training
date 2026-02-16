using System;
using System.Collections.Generic;

namespace TrafficViolationMonitoringSystem08
{

    class Program
    {
        static void Main(string[] args)
        {
            ViolationUtility utility = new ViolationUtility();

            while (true)
            {
                Console.WriteLine("1 -> Display Violations");
                Console.WriteLine("2 -> Pay Fine");
                Console.WriteLine("3 -> Add Violation");
                Console.WriteLine("4 -> Exit");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            utility.DisplayViolations();
                            break;

                        case 2:
                            Console.WriteLine("Enter Vehicle Number:");
                            string vehicle = Console.ReadLine();

                            Console.WriteLine("Enter Amount to Pay:");
                            int amount = int.Parse(Console.ReadLine());

                            utility.PayFine(vehicle, amount);
                            Console.WriteLine("Fine Paid Successfully");
                            break;

                        case 3:
                            Console.WriteLine("Enter VehicleNumber OwnerName FineAmount:");
                            string[] input = Console.ReadLine().Split(' ');

                            string vehicleNumber = input[0];
                            string owner = input[1];
                            int fine = int.Parse(input[2]);

                            Violation violation = new Violation(vehicleNumber, owner, fine);
                            utility.AddViolation(violation);

                            Console.WriteLine("Violation Added Successfully");
                            break;

                        case 4:
                            return;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
