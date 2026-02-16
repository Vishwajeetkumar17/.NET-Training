using System;
using System.Collections.Generic;

namespace FlightFareManagementSystem05
{

    class Program
    {
        static void Main(string[] args)
        {
            TicketUtility utility = new TicketUtility();

            while (true)
            {
                Console.WriteLine("1 -> Display Tickets");
                Console.WriteLine("2 -> Update Fare");
                Console.WriteLine("3 -> Add Ticket");
                Console.WriteLine("4 -> Exit");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            utility.DisplayTickets();
                            break;

                        case 2:
                            Console.WriteLine("Enter Ticket ID:");
                            string id = Console.ReadLine();

                            Console.WriteLine("Enter New Fare:");
                            int newFare = int.Parse(Console.ReadLine());

                            utility.UpdateFare(id, newFare);
                            Console.WriteLine("Fare Updated Successfully");
                            break;

                        case 3:
                            Console.WriteLine("Enter TicketId PassengerName Fare:");
                            string[] input = Console.ReadLine().Split(' ');

                            string ticketId = input[0];
                            string name = input[1];
                            int fare = int.Parse(input[2]);

                            Ticket ticket = new Ticket(ticketId, name, fare);
                            utility.AddTicket(ticket);

                            Console.WriteLine("Ticket Added Successfully");
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
