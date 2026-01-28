using System.Diagnostics.Metrics;

namespace BakeMeAWish
{
    public class CakeOrder
    {

        private Dictionary<string, double> orderMap = new Dictionary<string, double>();

        public void AddOrderDetails(string orderId, double cakeCost)
        {
            orderMap[orderId] = cakeCost;
        }
        public Dictionary<string, double> findOrdersAboveSpecifiedCost(double cakeCost)
        {
            Dictionary<string, double> aboveSpecifiedCost = new Dictionary<string, double>();
            foreach (var item in orderMap) {
                if (item.Value >= cakeCost)
                {
                    aboveSpecifiedCost[item.Key] = item.Value;
                }
            }
            return aboveSpecifiedCost;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            CakeOrder co = new CakeOrder();

            Console.WriteLine("Enter number of cake orders to be added ");
            string input = Console.ReadLine();

            if(int.TryParse(input, out int number))
            {
                Console.WriteLine("Enter the cake order details(Order Id: CakeCost)");
                for (int i = 0; i < number; i++)
                {
                    string? Input = Console.ReadLine();
                    string[] inputKeyValue = Input.Split(":");
                    co.AddOrderDetails(inputKeyValue[0], double.Parse(inputKeyValue[1]));
                }
            }
            Console.WriteLine("Enter the cost to search the cake orders");
            double search  = double.Parse(Console.ReadLine());
            co.findOrdersAboveSpecifiedCost(search);

            Console.WriteLine("Cake Orders above the specified cost");
            var AboveCost = co.findOrdersAboveSpecifiedCost(search);
            foreach(var item in AboveCost)
            {
                Console.WriteLine($"Order ID: {item.Key}, Cake Cost: {item.Value:F1}");
            }
        }
    }
}
