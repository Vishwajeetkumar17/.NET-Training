using System;
using FlexibleInventorySystem_Practice.Services;
using FlexibleInventorySystem_Practice.Models;


namespace FlexibleInventorySystem_Practice
{
    /// <summary>
    /// TODO: Implement console user interface
    /// </summary>
    class Program
    {
        private static InventoryManager _inventory = new InventoryManager();

        static void Main(string[] args)
        {
            // TODO: Display menu and handle user input
            // Options should include:
            // 1. Add Product
            // 2. Remove Product
            // 3. Update Quantity
            // 4. Find Product
            // 5. View All Products
            // 6. Generate Reports
            // 7. Check Low Stock
            // 8. Exit

            // Load sample data
            foreach (var product in SampleData.GetSampleProducts())
            {
                _inventory.AddProduct(product);
            }

            while (true)
            {
                DisplayMenu();
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProductMenu();
                        break;
                    case "2":
                        RemoveProductMenu();
                        break;
                    case "3":
                        UpdateQuantityMenu();
                        break;
                    case "4":
                        FindProductMenu();
                        break;
                    case "5":
                        ViewAllProductsMenu();
                        break;
                    case "6":
                        GenerateReportsMenu();
                        break;
                    case "7":
                        CheckLowStockMenu();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            // TODO: Display formatted menu
            Console.WriteLine("\n--- Inventory System Menu ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Update Quantity");
            Console.WriteLine("4. Find Product");
            Console.WriteLine("5. View All Products");
            Console.WriteLine("6. Generate Reports");
            Console.WriteLine("7. Check Low Stock");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");
        }

        static void AddProductMenu()
        {
            // TODO: Implement menu to add different product types
            // Ask user for product type
            // Collect appropriate properties
            // Add to inventory
            Console.WriteLine("Sample data is already loaded. To add a new product, implement this method as needed.");
        }

        static void RemoveProductMenu()
        {
            // TODO: Implement product removal
            Console.Write("Enter Product ID to remove: ");
            string? id = Console.ReadLine();
            if (_inventory.RemoveProduct(id ?? ""))
                Console.WriteLine("Product removed.");
            else
                Console.WriteLine("Product not found.");

        }

        static void UpdateQuantityMenu()
        {
            // TODO: Implement update quantity
            Console.Write("Enter Product ID to update: ");
            string? id = Console.ReadLine();
            Console.Write("Enter new quantity: ");
            if (int.TryParse(Console.ReadLine(), out int qty))
            {
                if (_inventory.UpdateQuantity(id ?? "", qty))
                    Console.WriteLine("Quantity updated.");
                else
                    Console.WriteLine("Product not found.");
            }
            else
            {
                Console.WriteLine("Invalid quantity.");
            }
        }

        static void FindProductMenu()
        {
            // TODO: Implement find product
            Console.Write("Enter Product ID to find: ");
            string? id = Console.ReadLine();
            var product = _inventory.FindProduct(id ?? "");
            if (product != null)
                Console.WriteLine(product.GetProductDetails());
            else
                Console.WriteLine("Product not found.");
        }

        static void ViewAllProductsMenu()
        {
            // TODO: Implement view all products
            var all = _inventory.GenerateInventoryReport();
            Console.WriteLine("--- All Products ---");
            Console.WriteLine(all);
        }

        static void GenerateReportsMenu()
        {
            // TODO: Implement generate reports
            Console.WriteLine("1. Category Summary");
            Console.WriteLine("2. Value Report");
            Console.WriteLine("3. Expiry Report (Groceries)");
            Console.Write("Choose report: ");
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine(_inventory.GenerateCategorySummary());
                    break;
                case "2":
                    Console.WriteLine(_inventory.GenerateValueReport());
                    break;
                case "3":
                    Console.Write("Enter days threshold: ");
                    if (int.TryParse(Console.ReadLine(), out int days))
                        Console.WriteLine(_inventory.GenerateExpiryReport(days));
                    else
                        Console.WriteLine("Invalid input.");
                    break;
                default:
                    Console.WriteLine("Invalid report option.");
                    break;
            }
        }

        static void CheckLowStockMenu()
        {
            // TODO: Implement check low stock
            Console.Write("Enter low stock threshold: ");
            if (int.TryParse(Console.ReadLine(), out int threshold))
            {
                var lowStock = _inventory.GetLowStockProducts(threshold);
                if (lowStock.Count == 0)
                {
                    Console.WriteLine("No low stock products.");
                }
                else
                {
                    Console.WriteLine("--- Low Stock Products ---");
                    foreach (var p in lowStock)
                        Console.WriteLine(p.GetProductDetails());
                }
            }
            else
            {
                Console.WriteLine("Invalid threshold.");
            }
        }

        // TODO: Add other menu methods
    }
}