using System;
using System.Collections.Generic;

namespace PharmacyMedicineInventorySystem01
{
    class Program
    {
        static void Main(string[] args)
        {
            MedicineUtility utility = new MedicineUtility();

            while (true)
            {
                Console.WriteLine("1 -> Display all medicines");
                Console.WriteLine("2 -> Update medicine price");
                Console.WriteLine("3 -> Add medicine");
                Console.WriteLine("4 -> Exit");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            utility.GetAllMedicines();
                            break;

                        case 2:
                            Console.WriteLine("Enter Medicine ID:");
                            string id = Console.ReadLine();

                            Console.WriteLine("Enter New Price:");
                            int newPrice = int.Parse(Console.ReadLine());

                            utility.UpdateMedicinePrice(id, newPrice);
                            Console.WriteLine("Price Updated Successfully");
                            break;

                        case 3:
                            Console.WriteLine("Enter MedicineID Name Price ExpiryYear:");
                            string[] input = Console.ReadLine().Split(' ');

                            string medId = input[0];
                            string name = input[1];
                            int price = int.Parse(input[2]);
                            int expiryYear = int.Parse(input[3]);

                            Medicine medicine = new Medicine(medId, name, price, expiryYear);
                            utility.AddMedicine(medicine);

                            Console.WriteLine("Medicine Added Successfully");
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
