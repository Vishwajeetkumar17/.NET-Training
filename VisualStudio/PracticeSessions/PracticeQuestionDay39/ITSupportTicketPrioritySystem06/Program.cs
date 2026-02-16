using System;
using System.Collections.Generic;

namespace ITSupportTicketPrioritySystem06
{

    class Program
    {
        static void Main(string[] args)
        {
            SupportTicketUtility utility = new SupportTicketUtility();

            while (true)
            {
                Console.WriteLine("1 -> Display Tickets by Priority");
                Console.WriteLine("2 -> Escalate Ticket");
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

                            utility.EscalateTicket(id);
                            Console.WriteLine("Ticket Escalated Successfully");
                            break;

                        case 3:
                            Console.WriteLine("Enter TicketId IssueDescription SeverityLevel:");
                            string[] input = Console.ReadLine().Split(' ');

                            string ticketId = input[0];
                            string description = input[1];
                            int severity = int.Parse(input[2]);

                            SupportTicket ticket = new SupportTicket(ticketId, description, severity);
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
