using System;
using System.Collections.Generic;
using System.Linq;

// Base product interface
public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}

public enum Category { Electronics, Clothing, Books, Groceries }

// 1. Create a generic repository for products
public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();

    // Implement method to add product with validation
    public void AddProduct(T product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product), "Product cannot be null");

        // Rule: Product ID must be unique
        if (_products.Any(p => p.Id == product.Id))
            throw new Exception("Duplicate Product ID");

        // Rule: Price must be positive
        if (product.Price <= 0)
            throw new Exception("Price must be positive");

        // Rule: Name cannot be null or empty
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new Exception("Name cannot be empty");

        // Add to collection if validation passes
        _products.Add(product);
    }

    // Create method to find products by predicate
    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        // Should return filtered products
        return _products.Where(predicate);
    }

    // Calculate total inventory value
    public decimal CalculateTotalValue()
    {
        // Return sum of all product prices
        return _products.Sum(p => p.Price);
    }
}

// 2. Specialized electronic product
public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

// 3. Create a discounted product wrapper
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;

    public DiscountedProduct(T product, decimal discountPercentage)
    {
        // Initialize with validation
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        // Discount must be between 0 and 100
        if (discountPercentage < 0 || discountPercentage > 100)
            throw new Exception("Discount must be between 0 and 100");

        _product = product;
        _discountPercentage = discountPercentage;
    }

    // Implement calculated price with discount
    public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);

    // Override ToString to show discount details
    public override string ToString()
    {
        return $"{_product.Name} | Original: {_product.Price} | " +
               $"Discount: {_discountPercentage}% | Final: {DiscountedPrice}";
    }
}

// 4. Inventory manager with constraints
public class InventoryManager
{
    // Create method that accepts any IProduct collection
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        // a) Print all product names and prices
        foreach (var item in products)
            Console.WriteLine($"{item.Name} - {item.Price}");

        // b) Find the most expensive product
        var expensive = products.OrderByDescending(p => p.Price).First();
        Console.WriteLine($"Most Expensive: {expensive.Name} ({expensive.Price})");

        // c) Group products by category
        var groups = products.GroupBy(p => p.Category);
        foreach (var g in groups)
        {
            Console.WriteLine($"Category: {g.Key}");
            foreach (var p in g)
                Console.WriteLine($"  {p.Name}");
        }

        // d) Apply 10% discount to Electronics over $500
        Console.WriteLine("Discounted Electronics:");
        foreach (var p in products.Where(p => p.Category == Category.Electronics && p.Price > 500))
        {
            Console.WriteLine(p.Price * 0.9m);
        }
    }

    // Implement bulk price update with delegate
    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
        where T : IProduct
    {
        try
        {
            foreach (var p in products)
            {
                // Since IProduct.Price has no setter,
                // update only known concrete types safely
                decimal newPrice = priceAdjuster(p);

                if (p is ElectronicProduct ep)
                    ep.Price = newPrice;
                // (Extend here if more product types added)
            }
        }
        catch
        {
            // Handle exceptions gracefully
            Console.WriteLine("Failed updating");
        }
    }
}

// 5. TEST SCENARIO
public class Program
{
    public static void Main()
    {
        // Create sample inventory with 5 products
        var repo = new ProductRepository<ElectronicProduct>();

        var p1 = new ElectronicProduct { Id = 1, Name = "Laptop", Price = 1200m, Brand = "Dell", WarrantyMonths = 24 };
        var p2 = new ElectronicProduct { Id = 2, Name = "Phone", Price = 800m, Brand = "Samsung", WarrantyMonths = 12 };
        var p3 = new ElectronicProduct { Id = 3, Name = "Headphones", Price = 150m, Brand = "Sony", WarrantyMonths = 6 };
        var p4 = new ElectronicProduct { Id = 4, Name = "Monitor", Price = 400m, Brand = "Dell", WarrantyMonths = 18 };
        var p5 = new ElectronicProduct { Id = 5, Name = "Tablet", Price = 600m, Brand = "Apple", WarrantyMonths = 12 };

        // Adding products with validation
        repo.AddProduct(p1);
        repo.AddProduct(p2);
        repo.AddProduct(p3);
        repo.AddProduct(p4);
        repo.AddProduct(p5);

        // Finding products by brand
        Console.WriteLine("Dell Products:");
        var dell = repo.FindProducts(p => p.Brand == "Dell");
        foreach (var p in dell)
            Console.WriteLine($"{p.Name} {p.Price}");

        // Calculating total value
        Console.WriteLine("\nTotal Value:");
        Console.WriteLine(repo.CalculateTotalValue());

        // Applying discounts
        Console.WriteLine("\nDiscount Examples:");
        foreach (var p in dell)
            Console.WriteLine(new DiscountedProduct<ElectronicProduct>(p, 10));

        // Processing mixed collection
        Console.WriteLine("\nProcessing Inventory:");
        var manager = new InventoryManager();
        manager.ProcessProducts(new List<IProduct> { p1, p2, p3, p4, p5 });

        // Updating prices
        Console.WriteLine("\nUpdating Prices (+5%):");
        var list = new List<ElectronicProduct> { p1, p2, p3, p4, p5 };
        manager.UpdatePrices(list, prod => prod.Price * 1.05m);

        foreach (var p in list)
            Console.WriteLine($"{p.Name} -> {p.Price}");
    }
}
