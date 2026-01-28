using System;
using System.Collections.Generic;

namespace HeavenHomes
{
    public class Apartment
    {
        private Dictionary<string, double> apartmentDetailsMap =
            new Dictionary<string, double>();

        public Dictionary<string, double> ApartmentDetailsMap
        {
            get { return apartmentDetailsMap; }
            set { apartmentDetailsMap = value; }
        }

        public void AddApartmentDetails(string apartmentNumber, double rent)
        {
            apartmentDetailsMap[apartmentNumber] = rent;
        }

        public double FindTotalRentOfApartmentsInTheGivenRange(double minimumRent, double maximumRent)
        {
            double total = 0;

            foreach (double rent in apartmentDetailsMap.Values)
            {
                if (rent >= minimumRent && rent <= maximumRent)
                {
                    total += rent;
                }
            }

            return total;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Apartment apartment = new Apartment();

            Console.WriteLine("Enter number of details to be added");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the details (Apartment number: Rent)");
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] parts = input.Split(':');

                string apartmentNumber = parts[0];
                double rent = double.Parse(parts[1]);

                apartment.AddApartmentDetails(apartmentNumber, rent);
            }

            Console.WriteLine("Enter the range to filter the details");
            double minimumRent = double.Parse(Console.ReadLine());
            double maximumRent = double.Parse(Console.ReadLine());

            double totalRent =
                apartment.FindTotalRentOfApartmentsInTheGivenRange(minimumRent, maximumRent);

            if (totalRent == 0)
            {
                Console.WriteLine("No apartments found in this range");
            }
            else
            {
                Console.WriteLine($"Total Rent in the range {minimumRent:F1} to {maximumRent:F1} USD:{totalRent:F1}");
            }
        }
    }
}
