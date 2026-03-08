using Microsoft.Data.SqlClient;

namespace CRUDOperation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cs = "Data Source=VISHWAJEET-RAJ;Initial Catalog=TaskDB;Integrated Security=True;TrustServerCertificate=True;";

            while (true)
            {
                Console.WriteLine("\nSelect operation:");
                Console.WriteLine("1. Read");
                Console.WriteLine("2. Insert");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice (1-5): ");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        StudentReader.Read(cs);
                        break;
                    case "2":
                        StudentInserter.Insert(cs);
                        break;
                    case "3":
                        StudentUpdater.Update(cs);
                        break;
                    case "4":
                        StudentDeleter.Delete(cs);
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
