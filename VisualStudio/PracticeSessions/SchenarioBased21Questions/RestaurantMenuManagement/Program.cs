namespace RestaurantMenuManagement
{
    public class MenuItem
    {
        public string ItemName { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public bool IsVegetarian { get; set; }
    }
    public class MenuManager
    {
        List<MenuItem> menuItems = new List<MenuItem>();
        public void AddMenuItem(string name, string category, double price, bool isVeg)
        {
            int key = Program.AllItem.Count + 1;
            MenuItem menuItem = new MenuItem()
            {
                ItemName = name,
                Category = category,
                Price = price,
                IsVegetarian = isVeg
            };
            menuItems.Add(menuItem);
            Program.AllItem.Add(key, new List<MenuItem> { menuItem });
        }
        public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
        {
            Dictionary<string, List<MenuItem>> groupItem = new Dictionary<string, List<MenuItem>>();
            foreach (var menuItem in Program.AllItem.Values)
            {
                foreach (var item in menuItem)
                {
                    if (!groupItem.ContainsKey(item.Category))
                    {
                        groupItem[item.Category] = new List<MenuItem>();
                    }
                    groupItem[item.Category].Add(item);
                }
            }
            return groupItem;
        }
        public List<MenuItem> GetVegetarianItems()
        {
            //List<MenuItem> vegItems = new List<MenuItem>();
            //foreach (var item in menuItems)
            //{
            //    if (item.IsVegetarian)
            //    {
            //        vegItems.Add(item);
            //    }
            //}
            //return vegItems;
            return menuItems.Where(i => i.IsVegetarian).ToList();
        }
        public double CalculateAveragePriceByCategory(string category)
        {
            //double price = 0;
            //int count = 0;
            //foreach(var item in menuItems)
            //{
            //    if(item.Category == category)
            //    {
            //        price += item.Price;
            //        count++;
            //    }
            //}
            //if(count == 0)
            //{
            //    return 0;
            //}
            //return price/count;
            return menuItems.Where(i => i.Category == category).Select(i => i.Price).DefaultIfEmpty(0).Average();
        }
    }
    public class Program
    {
        public static Dictionary<int, List<MenuItem>> AllItem = new Dictionary<int, List<MenuItem>>();
        static void Main(string[] args)
        {
            MenuManager manager = new MenuManager();

            while (true)
            {
                Console.WriteLine("1. Add Menu Item");
                Console.WriteLine("2. Group Items by Category");
                Console.WriteLine("3. Show Vegetarian Items");
                Console.WriteLine("4. Average Price by Category");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("Enter Item Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Category: ");
                    string category = Console.ReadLine();

                    Console.Write("Enter Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Is Vegetarian (true/false): ");
                    bool isVeg = bool.Parse(Console.ReadLine());

                    manager.AddMenuItem(name, category, price, isVeg);
                    Console.WriteLine("Menu item added successfully.\n");
                }
                else if (choice == 2)
                {
                    var grouped = manager.GroupItemsByCategory();

                    foreach (var cat in grouped)
                    {
                        Console.WriteLine($"Category: {cat.Key}");
                        foreach (var item in cat.Value)
                        {
                            Console.WriteLine(
                                $"{item.ItemName} - ₹{item.Price} - Veg: {item.IsVegetarian}"
                            );
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 3)
                {
                    var vegItems = manager.GetVegetarianItems();

                    if (vegItems.Count == 0)
                    {
                        Console.WriteLine("No vegetarian items found.\n");
                    }
                    else
                    {
                        foreach (var item in vegItems)
                        {
                            Console.WriteLine($"{item.ItemName} - ₹{item.Price}");
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 4)
                {
                    Console.Write("Enter Category: ");
                    string category = Console.ReadLine();

                    double avg = manager.CalculateAveragePriceByCategory(category);
                    Console.WriteLine($"Average price for {category}: ₹{avg}\n");
                }
                else if (choice == 5)
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
