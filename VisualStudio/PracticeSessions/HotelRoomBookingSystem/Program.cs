namespace HotelRoomBookingSystem
{
    public class Room
    {
        public int Roomnumber { get; set; }
        public string RoomType { get; set; }
        public double PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
    }
    public class HotelManager
    {
        private readonly List<Room> rooms = new List<Room>();
        public void AddRoom(int roomNumber, string type, double price)
        {
            int key = Program.AllRooms.Count + 1;
            Room room = new Room
            {
                Roomnumber = roomNumber,
                RoomType = type,
                PricePerNight = price,
                IsAvailable = true
            };
            rooms.Add(room);
            Program.AllRooms.Add(key, new List<Room> { room });
        }
        public Dictionary<string, List<Room>> GroupRoomsByType()
        {
            Dictionary<string, List<Room>> groupRooms = new Dictionary<string, List<Room>>();
            foreach (var roomList in Program.AllRooms.Values)
            {
                foreach (var room in roomList)
                {
                    if (!groupRooms.ContainsKey(room.RoomType))
                    {
                        groupRooms[room.RoomType] = new List<Room>();
                    }
                    groupRooms[room.RoomType].Add(room);

                }
            }
            return groupRooms;
        }
        public bool BookRoom(int roomNumber, int nights)
        {
            Room? room = rooms.FirstOrDefault(r => r.Roomnumber == roomNumber);
            if (room == null || room.IsAvailable == false) return false;

            double Price = room.PricePerNight * nights;
            room.IsAvailable = false;
            Console.WriteLine($"Cost of RoomNumber: {roomNumber} for {nights} Nights = {Price}");
            return true;
        }
        public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
        {
            List<Room> availableRoom = new List<Room>();
            foreach (var room in rooms)
            {
                if(room.IsAvailable && room.PricePerNight >= min && room.PricePerNight <= max)
                {
                    availableRoom.Add(room);
                }
            }
            return availableRoom;
        }
    }
    public class Program
    {
        public static Dictionary<int, List<Room>> AllRooms = new Dictionary<int, List<Room>>();

        static void Main(string[] args)
        {
            HotelManager manager = new HotelManager();

            while (true)
            {
                Console.WriteLine("1. Add Room");
                Console.WriteLine("2. Group Rooms by Type");
                Console.WriteLine("3. Book a Room");
                Console.WriteLine("4. Show Available Rooms by Price Range");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("Enter Room Number: ");
                    int number = int.Parse(Console.ReadLine());

                    Console.Write("Enter Room Type: ");
                    string type = Console.ReadLine();

                    Console.Write("Enter Price Per Night: ");
                    double price = double.Parse(Console.ReadLine());

                    manager.AddRoom(number, type, price);
                    Console.WriteLine("Room added successfully.\n");
                }
                else if (choice == 2)
                {
                    var groupedRooms = manager.GroupRoomsByType();

                    foreach (var item in groupedRooms)
                    {
                        Console.WriteLine($"Room Type: {item.Key}");
                        foreach (Room room in item.Value)
                        {
                            Console.WriteLine(
                                $"Room No: {room.Roomnumber}, Price: {room.PricePerNight}, Available: {room.IsAvailable}"
                            );
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("Enter Room Number to Book: ");
                    int roomNo = int.Parse(Console.ReadLine());

                    Console.Write("Enter Number of Nights: ");
                    int nights = int.Parse(Console.ReadLine());

                    bool success = manager.BookRoom(roomNo, nights);

                    if (!success)
                        Console.WriteLine("Room not available or invalid room number.\n");
                    else
                        Console.WriteLine();
                }
                else if (choice == 4)
                {
                    Console.Write("Enter Minimum Price: ");
                    double min = double.Parse(Console.ReadLine());

                    Console.Write("Enter Maximum Price: ");
                    double max = double.Parse(Console.ReadLine());

                    var rooms = manager.GetAvailableRoomsByPriceRange(min, max);

                    if (rooms.Count == 0)
                    {
                        Console.WriteLine("No rooms available in this price range.\n");
                    }
                    else
                    {
                        foreach (Room room in rooms)
                        {
                            Console.WriteLine(
                                $"Room No: {room.Roomnumber}, Type: {room.RoomType}, Price: {room.PricePerNight}"
                            );
                        }
                        Console.WriteLine();
                    }
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
