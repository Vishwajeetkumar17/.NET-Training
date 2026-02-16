using System;
using System.Collections.Generic;

namespace InvestmentRiskClassificationSystem07
{

    class Program
    {
        static void Main(string[] args)
        {
            InvestmentUtility utility = new InvestmentUtility();

            while (true)
            {
                Console.WriteLine("1 -> Display Investments");
                Console.WriteLine("2 -> Update Risk");
                Console.WriteLine("3 -> Add Investment");
                Console.WriteLine("4 -> Exit");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            utility.DisplayInvestments();
                            break;

                        case 2:
                            Console.WriteLine("Enter Investment ID:");
                            string id = Console.ReadLine();

                            Console.WriteLine("Enter New Risk Rating (1-5):");
                            int newRisk = int.Parse(Console.ReadLine());

                            utility.UpdateRisk(id, newRisk);
                            Console.WriteLine("Risk Updated Successfully");
                            break;

                        case 3:
                            Console.WriteLine("Enter InvestmentId AssetName RiskRating:");
                            string[] input = Console.ReadLine().Split(' ');

                            string invId = input[0];
                            string asset = input[1];
                            int risk = int.Parse(input[2]);

                            Investment investment = new Investment(invId, asset, risk);
                            utility.AddInvestment(investment);

                            Console.WriteLine("Investment Added Successfully");
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
