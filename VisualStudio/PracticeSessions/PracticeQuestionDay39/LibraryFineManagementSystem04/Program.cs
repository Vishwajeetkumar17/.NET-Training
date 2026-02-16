using System;
using System.Collections.Generic;

namespace LibraryFineManagementSystem04
{

    class Program
    {
        static void Main(string[] args)
        {
            MemberUtility utility = new MemberUtility();

            while (true)
            {
                Console.WriteLine("1 -> Display Members by Fine");
                Console.WriteLine("2 -> Pay Fine");
                Console.WriteLine("3 -> Add Member");
                Console.WriteLine("4 -> Exit");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            utility.DisplayMembers();
                            break;

                        case 2:
                            Console.WriteLine("Enter Member ID:");
                            string id = Console.ReadLine();

                            Console.WriteLine("Enter Amount to Pay:");
                            int amount = int.Parse(Console.ReadLine());

                            utility.PayFine(id, amount);
                            Console.WriteLine("Fine Paid Successfully");
                            break;

                        case 3:
                            Console.WriteLine("Enter MemberId Name FineAmount:");
                            string[] input = Console.ReadLine().Split(' ');

                            string memberId = input[0];
                            string name = input[1];
                            int fine = int.Parse(input[2]);

                            Member member = new Member(memberId, name, fine);
                            utility.AddMember(member);

                            Console.WriteLine("Member Added Successfully");
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
