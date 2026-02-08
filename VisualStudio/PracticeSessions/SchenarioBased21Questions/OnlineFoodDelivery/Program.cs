namespace OnlineFoodDelivery
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string CuisineType { get; set; }
        public string Location { get; set; }
        public double DeliveryCharge { get; set; }
    }
    public class FoodItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int RestaurantId { get; set; }
    }
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<FoodItem> Items { get; set; } = new List<FoodItem>();
        public DateTime OrderTime { get; set; }
        public string Status { get; set; }
        public double TotalAmount { get; set; }
    }
    public class DeliveryManager
    {
        private readonly List<Restaurant> restaurants = new List<Restaurant>();
        private readonly List<FoodItem> foodItems = new List<FoodItem>();
        private readonly List<Order> orders = new List<Order>();
        private int restaurantID = 1;
        private int foodId = 1;
        private int orderId = 1;
        public void AddRestaurant(string name, string cuisine, string location, double charge)
        {
            restaurants.Add(new Restaurant {
                RestaurantId = restaurantID++,
                Name = name,
                CuisineType = cuisine,
                Location = location,
                DeliveryCharge = charge
            });
        }
        public void AddFoodItem(int restaurantId, string name, string category, double price)
        {
            foodItems.Add(new FoodItem { 
                ItemId = foodId++,
                Name = name,
                Category = category,
                Price = price,
                RestaurantId = restaurantId,
            });
        }
        public Dictionary<string, List<Restaurant>> GroupRestaurantsByCuisine()
        {
            Dictionary<string, List<Restaurant>> groupRestaurants = new Dictionary<string, List<Restaurant>>();

            foreach(var restaurant in restaurants)
            {
                if (!groupRestaurants.ContainsKey(restaurant.CuisineType))
                {
                    groupRestaurants[restaurant.CuisineType] = new List<Restaurant>();
                }
                groupRestaurants[restaurant.CuisineType].Add(restaurant);
            }
            return groupRestaurants;
        }
        public bool PlaceOrder(int customerId, List<int> itemIds)
        {
            if (itemIds == null || itemIds.Count == 0)
                return false;

            Order order = new Order
            {
                OrderId = orderId++,
                CustomerId = customerId,
                OrderTime = DateTime.Now,
                Status = "Pending",
                TotalAmount = 0
            };

            foreach (int id in itemIds)
            {
                FoodItem found = null;

                foreach (var food in foodItems)
                {
                    if (food.ItemId == id)
                    {
                        found = food;
                        break;
                    }
                }
                if (found == null)
                {
                    Console.WriteLine($"Item ID {id} not found.");
                    return false;
                }
                order.Items.Add(found);
                order.TotalAmount += found.Price;
            }

            orders.Add(order);
            return true;
        }
        public List<Order> GetPendingOrders()
        {
            List<Order> pendingOrders = new List<Order>();
            foreach(var order in orders)
            {
                if(order.Status == "Pending")
                {
                    pendingOrders.Add(order);
                }
            }
            return pendingOrders;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            DeliveryManager manager = new DeliveryManager();

            while (true)
            {
                Console.WriteLine("1. Add Restaurant");
                Console.WriteLine("2. Add Food Item");
                Console.WriteLine("3. Group Restaurants by Cuisine");
                Console.WriteLine("4. Place Order");
                Console.WriteLine("5. View Pending Orders");
                Console.WriteLine("6. Exit");
                Console.Write("Choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Cuisine: ");
                    string cuisine = Console.ReadLine();

                    Console.Write("Location: ");
                    string loc = Console.ReadLine();

                    Console.Write("Delivery Charge: ");
                    double charge = double.Parse(Console.ReadLine());

                    manager.AddRestaurant(name, cuisine, loc, charge);
                    Console.WriteLine("Restaurant added.\n");
                }
                else if (choice == 2)
                {
                    Console.Write("Restaurant ID: ");
                    int rid = int.Parse(Console.ReadLine());

                    Console.Write("Food Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Category: ");
                    string cat = Console.ReadLine();

                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine());

                    manager.AddFoodItem(rid, name, cat, price);
                    Console.WriteLine("Food item added.\n");
                }
                else if (choice == 3)
                {
                    var grouped = manager.GroupRestaurantsByCuisine();

                    foreach (var g in grouped)
                    {
                        Console.WriteLine($"Cuisine: {g.Key}");
                        foreach (var r in g.Value)
                        {
                            Console.WriteLine($"ID:{r.RestaurantId} {r.Name}");
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 4)
                {
                    Console.Write("Customer ID: ");
                    int cid = int.Parse(Console.ReadLine());

                    Console.Write("Enter Item IDs (comma separated): ");
                    string input = Console.ReadLine();

                    List<int> ids = new List<int>();
                    foreach (var s in input.Split(','))
                        ids.Add(int.Parse(s.Trim()));

                    bool success = manager.PlaceOrder(cid, ids);
                    Console.WriteLine(success ? "Order placed.\n" : "Order failed.\n");
                }
                else if (choice == 5)
                {
                    var pending = manager.GetPendingOrders();

                    foreach (var o in pending)
                    {
                        Console.WriteLine($"Order {o.OrderId} Amount:{o.TotalAmount}");
                    }
                    Console.WriteLine();
                }
                else if (choice == 6)
                {
                    break;
                }
            }
        }
    }
}
