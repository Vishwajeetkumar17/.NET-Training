using System.Security.Cryptography.X509Certificates;

namespace AdvancedCallback
{
    public delegate void Notify(string message);
    public class OrderService
    {
        public void PlaceOrder(string orderId, Notify callback)
        {
            Console.WriteLine($"Order {orderId} Placed.");
            callback?.Invoke($"Order {orderId} Conformation Sent!");
        }

        static void Main()
        {
            var service = new OrderService();
            service.PlaceOrder("ORD-101", SendEmail);
            service.PlaceOrder("ORD-102", SendSMS);
        }
        static void SendEmail(string message)
        {
            Console.WriteLine("EMAIL: " + message);
        }
        static void SendSMS(string message) => Console.WriteLine("SMS: " + message);
    }
}
