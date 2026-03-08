using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

    // TODO: Implement method to add product with validation
    public void AddProduct(T product)
    {

        // Rule: Product ID must be unique
        if (!_products.Any(p => p.Id == product.Id) && product.Price > 0 && !string.IsNullOrEmpty(product.Name))
        {
            _products.Add(product);
        }
        // Rule: Price must be positive
        // Rule: Name cannot be null or empty
        // Add to collection if validation passes
    }

    // TODO: Create method to find products by predicate
    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        // Should return filtered products
        return _products.Where(predicate);
    }

    // TODO: Calculate total inventory value
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
        // TODO: Initialize with validation
        // Discount must be between 0 and 100
        _product = product;
        if (discountPercentage >= 0 && discountPercentage <= 100)
            _discountPercentage = discountPercentage;
        else
            throw new Exception("Discount should be grater than 0 and less than 100.");
    }

    // TODO: Implement calculated price with discount
    public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);

    // TODO: Override ToString to show discount details
    public override string ToString()
    {
        return $"{DiscountedPrice}";
    }
}

// 4. Inventory manager with constraints
public class InventoryManager : IProduct
{
    // TODO: Create method that accepts any IProduct collection
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        // a) Print all product names and prices
        foreach (var item in products)
        {
            Console.WriteLine($"Name: {item.Name}, Prices: {item.Price}");
        }
        // b) Find the most expensive product
        decimal expensive = products.MaxBy(p => p.Price);
        Console.WriteLine("Expensive Product: " + expensive);
        // c) Group products by category
        var groupProduct = products.GroupBy(p => p.Category);
        foreach (var group in groupProduct)
        {
            Console.WriteLine($"Category: {g.Key}");
            foreach (var p in g)
                Console.WriteLine($"  {p.Name}");
        }
        // d) Apply 10% discount to Electronics over $500
        Console.WriteLine("Discounted Electronics:");
        foreach (var p in products.Where(p => p.Category == Category.Electronics && p.Price > 500))
        {
            
        }
    }

    // TODO: Implement bulk price update with delegate
    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
        where T : IProduct
    {
        // Apply priceAdjuster to each product
        foreach (var item in products)
        {
            decimal newPrice = priceAdjuster(item);
            if(item is ElectronicProduct ep)
            {
                ep.Price = newPrice;
            }
        }

        // Handle exceptions gracefully
    }
}

public class Program
{
    public static void Main()
    {
        // Repository
        var repo = new ProductRepository<ElectronicProduct>();

        // Sample products (5)
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

        // Find products by brand (Dell)
        Console.WriteLine("Products by brand Dell:");
        var dellProducts = repo.FindProducts(p => p.Brand == "Dell");
        foreach (var p in dellProducts)
            Console.WriteLine($"{p.Name} - {p.Price}");

        // Total value before discount
        Console.WriteLine("\nTotal inventory value:");
        Console.WriteLine(repo.CalculateTotalValue());

        // Apply discounts
        Console.WriteLine("\nApplying discounts:");
        var discounted = new List<DiscountedProduct<ElectronicProduct>>();
        foreach (var p in dellProducts)
        {
            var dp = new DiscountedProduct<ElectronicProduct>(p, 10);
            discounted.Add(dp);
            Console.WriteLine(dp);
        }

        // Mixed collection processing
        Console.WriteLine("\nProcessing mixed collection:");
        var manager = new InventoryManager();
        manager.ProcessProducts(new List<IProduct> { p1, p2, p3, p4, p5 });

        // Bulk price update
        Console.WriteLine("\nUpdating prices (+5%):");
        var list = new List<ElectronicProduct> { p1, p2, p3, p4, p5 };
        manager.UpdatePrices(list, prod => prod.Price * 1.05m);

        foreach (var p in list)
            Console.WriteLine($"{p.Name} -> {p.Price}");

        // Total value after update
        Console.WriteLine("\nTotal inventory value after update:");
        foreach (var p in list)
            Console.WriteLine($"{p.Name}: {p.Price}");
    }

    // 5. TEST SCENARIO: Your tasks:
    // a) Implement all TODO methods with proper error handling
    // b) Create a sample inventory with at least 5 products
    // c) Demonstrate:
    //    - Adding products with validation
    //    - Finding products by brand (for electronics)
    //    - Applying discounts
    //    - Calculating total value before/after discount
    //    - Handling a mixed collection of different product types
}