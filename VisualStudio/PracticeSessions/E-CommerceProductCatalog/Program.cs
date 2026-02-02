namespace E_CommerceProductCatalog
{
    public class Product
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
    }
    public class InventoryManager
    {
        public void AddProduct(string name, string category, double price, int stock)
        {
            int key = Program.AllProducts.Count + 1;
            Product product = new Product()
            {
                ProductCode = "P00" + key,
                ProductName = name,
                Category = category,
                Price = price,
                StockQuantity = stock
            };
            Program.AllProducts.Add(key, new List<Product> { product });
        }
        public SortedDictionary<string, List<Product>> GroupProductsByCategory()
        {
            SortedDictionary<string, List<Product>> groupProduct = new SortedDictionary<string, List<Product>>();
            foreach(var productItem in Program.AllProducts.Values)
            {
                foreach(var product in productItem)
                {
                    if (!groupProduct.ContainsKey(product.Category))
                    {
                        groupProduct[product.Category] = new List<Product>();
                    }
                    groupProduct[product.Category].Add(product);
                }
            }
            return groupProduct;
        }
        public bool UpdateStock(string productCode, int quantity)
        {
            foreach(var product in Program.AllProducts.Values)
            {
                foreach(var productItem in product)
                {
                    if(productItem.ProductCode == productCode)
                    {
                        productItem.StockQuantity += quantity;
                        return true;
                    }
                }
            }
            return false;
        }
        public List<Product> GetProductsBelowPrice(double maxPrice)
        {
            List<Product> products = new List<Product>();
            foreach(var product in Program.AllProducts.Values)
            {
                foreach (var productItem in product)
                {
                    if(productItem.Price < maxPrice)
                    {
                        products.Add(productItem);
                    }
                }
            }
            return products;
        }
        public Dictionary<string, int> GetCategoryStockSummary()
        {
            Dictionary<string, int> stockSummary = new Dictionary<string, int>();
            foreach(var product in Program.AllProducts.Values)
            {
                foreach(var productItem in product)
                {
                    if (!stockSummary.ContainsKey(productItem.Category))
                    {
                        stockSummary[productItem.Category] = 0;
                    }
                    stockSummary[productItem.Category] += productItem.StockQuantity;
                }
            }
            return stockSummary;
        }
    }
    public class Program
    {
        public static SortedDictionary<int, List<Product>> AllProducts = new SortedDictionary<int, List<Product>>();
        static void Main(string[] args)
        {
            InventoryManager manager = new InventoryManager();

            while (true)
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Group Products by Category");
                Console.WriteLine("3. Update Stock");
                Console.WriteLine("4. Get Products Below Price");
                Console.WriteLine("5. Category Stock Summary");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("Enter Product Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Category: ");
                    string category = Console.ReadLine();

                    Console.Write("Enter Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Enter Stock Quantity: ");
                    int stock = int.Parse(Console.ReadLine());

                    manager.AddProduct(name, category, price, stock);
                    Console.WriteLine("Product added successfully.\n");
                }
                else if (choice == 2)
                {
                    var grouped = manager.GroupProductsByCategory();

                    foreach (var cat in grouped)
                    {
                        Console.WriteLine($"Category: {cat.Key}");
                        foreach (var product in cat.Value)
                        {
                            Console.WriteLine(
                                $"{product.ProductCode} - {product.ProductName} - ₹{product.Price} - Stock: {product.StockQuantity}"
                            );
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("Enter Product Code: ");
                    string code = Console.ReadLine();

                    Console.Write("Enter Quantity to Add: ");
                    int qty = int.Parse(Console.ReadLine());

                    bool updated = manager.UpdateStock(code, qty);

                    Console.WriteLine(updated ? "Stock updated.\n" : "Product not found.\n");
                }
                else if (choice == 4)
                {
                    Console.Write("Enter Max Price: ");
                    double maxPrice = double.Parse(Console.ReadLine());

                    var products = manager.GetProductsBelowPrice(maxPrice);

                    foreach (var p in products)
                    {
                        Console.WriteLine($"{p.ProductName} - ₹{p.Price}");
                    }
                    Console.WriteLine();
                }
                else if (choice == 5)
                {
                    var summary = manager.GetCategoryStockSummary();

                    foreach (var item in summary)
                    {
                        Console.WriteLine($"{item.Key} : Total Stock = {item.Value}");
                    }
                    Console.WriteLine();
                }
                else if (choice == 6)
                {
                    Console.WriteLine("Exiting application.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.\n");
                }
            }
        }
    }
}
