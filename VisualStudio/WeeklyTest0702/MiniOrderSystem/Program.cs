using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MiniOrderSystem
{

    public class Customer
    {
        public string Id { get; }
        public string Name { get; }

        public Customer(string id, string name)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Customer id invalid");

            Id = id;
            Name = name ?? "";
        }
    }

    public class Product
    {
        private readonly object _lock = new object();

        public string Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Stock { get; private set; }

        public Product(string id, string name, decimal price, int stock)
        {
            if (price <= 0 || stock < 0)
                throw new ArgumentException("Invalid product");

            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public void DeductStock(int qty)
        {
            lock (_lock)
            {
                if (Stock < qty)
                    throw new StockUnavailableException($"{Name} out of stock");

                Stock -= qty;
            }
        }
    }

    public class OrderItem
    {
        public Product Product { get; }
        public int Quantity { get; }
        public decimal LineTotal => Product.Price * Quantity;

        public OrderItem(Product p, int qty)
        {
            if (qty <= 0)
                throw new ArgumentException("Quantity invalid");

            Product = p;
            Quantity = qty;
        }
    }

    public class Payment
    {
        public decimal Amount { get; }
        public bool Success { get; private set; }

        public Payment(decimal amount)
        {
            Amount = amount;
        }

        public void Process()
        {
            if (Amount <= 0)
                throw new PaymentFailedException("Invalid payment amount");

            Success = true;
        }
    }

    public class Order
    {
        public string InvoiceNo { get; }
        public Customer Customer { get; }
        public List<OrderItem> Items { get; }
        public decimal Discount { get; }
        public decimal TotalAmount { get; }
        public Payment Payment { get; }

        public Order(string invoice,
                     Customer customer,
                     List<OrderItem> items,
                     decimal discount,
                     Payment payment)
        {
            InvoiceNo = invoice;
            Customer = customer;
            Items = items;
            Discount = discount;
            TotalAmount = items.Sum(i => i.LineTotal) - discount;
            Payment = payment;
        }
    }

    public interface ICoupon
    {
        decimal Apply(decimal total);
    }

    public class PercentageCoupon : ICoupon
    {
        private readonly decimal _percent;
        private readonly decimal _minOrder;

        public PercentageCoupon(decimal percent, decimal minOrder)
        {
            _percent = percent;
            _minOrder = minOrder;
        }

        public decimal Apply(decimal total)
        {
            if (total < _minOrder)
                throw new CouponInvalidException("Order below minimum");

            return total * _percent / 100m;
        }
    }

    public class Cart
    {
        private readonly List<OrderItem> _items = new();

        public void Add(Product p, int qty)
        {
            _items.Add(new OrderItem(p, qty));
        }

        public List<OrderItem> Items => _items;

        public decimal Total => _items.Sum(i => i.LineTotal);

        public void Clear() => _items.Clear();
    }

    public class OrderService
    {
        private int _invoiceCounter = 0;
        private readonly object _lock = new();

        public Order PlaceOrder(Customer customer, Cart cart, ICoupon coupon = null)
        {
            if (!cart.Items.Any())
                throw new OrderException("Cart empty");

            decimal total = cart.Total;
            decimal discount = 0;

            if (coupon != null)
                discount = coupon.Apply(total);

            decimal payable = total - discount;

            foreach (var item in cart.Items)
                item.Product.DeductStock(item.Quantity);

            string invoice = GenerateInvoice();

            var payment = new Payment(payable);
            payment.Process();

            var order = new Order(
                invoice,
                customer,
                new List<OrderItem>(cart.Items),
                discount,
                payment);

            cart.Clear();

            return order;
        }

        private string GenerateInvoice()
        {
            lock (_lock)
            {
                _invoiceCounter++;
                return $"INV-{DateTime.UtcNow:yyyyMMdd}-{_invoiceCounter}";
            }
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter Customer Id: ");
                string cid = Console.ReadLine();

                Console.Write("Enter Customer Name: ");
                string cname = Console.ReadLine();

                var customer = new Customer(cid, cname);

                Console.Write("Number of Products: ");
                int n = int.Parse(Console.ReadLine());

                var products = new Dictionary<string, Product>();

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"\nProduct {i + 1}");

                    Console.Write("Id: ");
                    string id = Console.ReadLine();

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    Console.Write("Stock: ");
                    int stock = int.Parse(Console.ReadLine());

                    products[id] = new Product(id, name, price, stock);
                }

                var cart = new Cart();

                Console.Write("\nItems to add to cart: ");
                int items = int.Parse(Console.ReadLine());

                for (int i = 0; i < items; i++)
                {
                    Console.WriteLine($"\nCart Item {i + 1}");

                    Console.Write("Product Id: ");
                    string pid = Console.ReadLine();

                    Console.Write("Quantity: ");
                    int qty = int.Parse(Console.ReadLine());

                    cart.Add(products[pid], qty);
                }

                Console.Write("\nApply coupon? (y/n): ");
                ICoupon coupon = null;

                if (Console.ReadLine().ToLower() == "y")
                {
                    Console.Write("Discount %: ");
                    decimal percent = decimal.Parse(Console.ReadLine());

                    Console.Write("Minimum Order Amount: ");
                    decimal min = decimal.Parse(Console.ReadLine());

                    coupon = new PercentageCoupon(percent, min);
                }

                var service = new OrderService();
                var order = service.PlaceOrder(customer, cart, coupon);

                Console.WriteLine("\n===== ORDER SUCCESS =====");
                Console.WriteLine($"Invoice: {order.InvoiceNo}");
                Console.WriteLine($"Total Paid: {order.TotalAmount}");
                Console.WriteLine("Items:");

                foreach (var i in order.Items)
                    Console.WriteLine($"{i.Product.Name} x{i.Quantity}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOrder Failed: {ex.Message}");
            }
        }
    }
}
