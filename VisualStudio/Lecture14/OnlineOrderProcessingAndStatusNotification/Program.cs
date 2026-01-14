using System;
using System.Collections.Generic;

namespace OnlineOrderProcessingAndStatusNotification
{
    #region Enums & Delegate

    public enum OrderStatus
    {
        Created,
        Paid,
        Packed,
        Shipped,
        Delivered,
        Cancelled
    }

    // Delegate for notifications
    public delegate void OrderStatusChangedHandler(
        Order order,
        OrderStatus oldStatus,
        OrderStatus newStatus
    );

    #endregion

    #region Models

    public class Product
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }

    public class Customer
    {
        public int Id { get; }
        public string Name { get; }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class OrderItem
    {
        public Product Product { get; }
        public int Quantity { get; }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal GetSubTotal()
        {
            return Product.Price * Quantity;
        }
    }

    public class OrderStatusLog
    {
        public OrderStatus Status { get; }
        public DateTime TimeStamp { get; }

        public OrderStatusLog(OrderStatus status)
        {
            Status = status;
            TimeStamp = DateTime.Now;
        }
    }

    #endregion

    class Program
    {
        static void Main()
        {
            // Products
            Dictionary<int, Product> products = new Dictionary<int, Product>
            {
                {1, new Product(1, "Laptop", 60000)},
                {2, new Product(2, "Mouse", 800)},
                {3, new Product(3, "Keyboard", 1500)},
                {4, new Product(4, "Monitor", 12000)},
                {5, new Product(5, "Headphones", 2000)}
            };

            // Customers
            Customer c1 = new Customer(1, "Amit");
            Customer c2 = new Customer(2, "Neha");
            Customer c3 = new Customer(3, "Rahul");

            // Orders
            List<Order> orders = new List<Order>();

            Order o1 = new Order(101, c1);
            o1.AddItem(new OrderItem(products[1], 1));
            o1.AddItem(new OrderItem(products[2], 2));

            Order o2 = new Order(102, c2);
            o2.AddItem(new OrderItem(products[3], 1));
            o2.AddItem(new OrderItem(products[5], 1));

            Order o3 = new Order(103, c3);
            o3.AddItem(new OrderItem(products[4], 2));

            orders.Add(o1);
            orders.Add(o2);
            orders.Add(o3);

            // Attach delegate subscribers
            foreach (var order in orders)
            {
                order.StatusChanged += NotificationService.CustomerNotification;
                order.StatusChanged += NotificationService.LogisticsNotification;
            }

            Console.WriteLine("---- ORDER STATUS FLOW ----");

            try
            {
                o1.ChangeStatus(OrderStatus.Paid);
                o1.ChangeStatus(OrderStatus.Packed);
                o1.ChangeStatus(OrderStatus.Shipped);
                o1.ChangeStatus(OrderStatus.Delivered);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\n---- ORDER REPORT ----");

            foreach (var order in orders)
            {
                PrintOrderReport(order);
            }
        }

        static void PrintOrderReport(Order order)
        {
            Console.WriteLine($"\nOrder ID: {order.Id}");
            Console.WriteLine($"Customer: {order.Customer.Name}");
            Console.WriteLine($"Current Status: {order.CurrentStatus}");
            Console.WriteLine("Items:");

            foreach (var item in order.Items)
            {
                Console.WriteLine(
                    $" - {item.Product.Name} x {item.Quantity} = {item.GetSubTotal()}"
                );
            }

            Console.WriteLine($"Total Amount: {order.CalculateTotal()}");

            Console.WriteLine("Status Timeline:");
            foreach (var log in order.StatusHistory)
            {
                Console.WriteLine($" {log.TimeStamp} -> {log.Status}");
            }
        }
    }
}
