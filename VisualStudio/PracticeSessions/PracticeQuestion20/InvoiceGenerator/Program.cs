using System.Text;

namespace InvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            const int itemCount = 5;

            StringBuilder invoice = new StringBuilder();
            decimal grandTotal = 0;

            invoice.AppendLine("=========== INVOICE ===========");
            invoice.AppendLine(String.Format("{0,-15} {1,5} {2,10} {3,12}",
                                             "Item", "Qty", "Price", "Total"));
            invoice.AppendLine("-----------------------------------------------");

            for (int i = 1; i <= itemCount; i++)
            {
                Console.Write($"Item {i} Name: ");
                string name = Console.ReadLine();

                Console.Write($"Qty: ");
                int qty = int.Parse(Console.ReadLine());

                Console.Write($"Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                decimal lineTotal = qty * price;
                grandTotal += lineTotal;

                invoice.AppendLine(
                    String.Format("{0,-15} {1,5} {2,10:F2} {3,12:F2}",
                                  name, qty, price, lineTotal));
            }

            invoice.AppendLine("-----------------------------------------------");
            invoice.AppendLine($"Grand Total: {grandTotal:F2}");
            invoice.AppendLine("===============================================");

            Console.WriteLine();
            Console.WriteLine(invoice.ToString());
        }
    }
}