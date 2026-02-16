using System;

namespace BookStoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO:
            // 1. Read initial input
            try
            {
                string[] book = Console.ReadLine().Split(' ');

                Book book1 = new Book() { Id = book[0], Title = book[1], Author = book[2], Price = int.Parse(book[3]), Stock = int.Parse(book[4]) };

                BookUtility utility = new BookUtility(book1);
                // Format: BookID Title Price Stock

                bool flag = true;
                while (flag)
                {
                    // TODO:
                    // Display menu:
                    Console.WriteLine("Menu: ");
                    // 1 -> Display book details
                    Console.WriteLine("1 -> Display book details: ");
                    // 2 -> Update book price
                    Console.WriteLine("2 -> Update book price");
                    // 3 -> Update book stock
                    Console.WriteLine("3 -> Update book stock");
                    // 4 -> Exit
                    Console.WriteLine("4 -> Exit");

                    Console.WriteLine("\nEnter Choice");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            utility.GetBookDetails();
                            break;

                        case 2:
                            // TODO:
                            // Read new price
                            int newPrice = int.Parse(Console.ReadLine());
                            utility.UpdateBookPrice(newPrice);
                            // Call UpdateBookPrice()
                            break;

                        case 3:
                            // TODO:
                            // Read new stock
                            int stock = int.Parse(Console.ReadLine());
                            // Call UpdateBookStock()
                            utility.UpdateBookStock(stock);
                            break;

                        case 4:
                            Console.WriteLine("Thank You");
                            flag = false;
                            break;

                        default:
                            // TODO: Handle invalid choice
                            flag = false;
                            break;
                    }
                }
            }
            catch(InvalidBookDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
