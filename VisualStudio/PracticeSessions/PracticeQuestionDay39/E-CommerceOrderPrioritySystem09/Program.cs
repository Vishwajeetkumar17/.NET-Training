using System;
using System.Collections.Generic;

namespace E_CommerceOrderPrioritySystem09
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderUtility utility = new OrderUtility();

            while (true)
            {
                Console.WriteLine("1 -> Display Orders");
                Console.WriteLine("2 -> Update Order");
                Console.WriteLine("3 -> Add Order");
                Console.WriteLine("4 -> Exit");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            utility.DisplayOrders();
                            break;

                        case 2:
                            Console.WriteLine("Enter Order ID:");
                            string id = Console.ReadLine();

                            Console.WriteLine("Enter New Order Amount:");
                            int newAmount = int.Parse(Console.ReadLine());

                            utility.UpdateOrder(id, newAmount);
                            Console.WriteLine("Order Updated Successfully");
                            break;

                        case 3:
                            Console.WriteLine("Enter OrderId CustomerName OrderAmount:");
                            string[] input = Console.ReadLine().Split(' ');

                            string orderId = input[0];
                            string name = input[1];
                            int amount = int.Parse(input[2]);

                            Order order = new Order(orderId, name, amount);
                            utility.AddOrder(order);

                            Console.WriteLine("Order Added Successfully");
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
