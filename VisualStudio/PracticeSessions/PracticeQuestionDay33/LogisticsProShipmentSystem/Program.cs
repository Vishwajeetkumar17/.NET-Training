namespace LogisticsProShipmentSystem
{
    public class Shipment
    {
        public string ShipmentCode { get; set; }
        public string TransportMode { get; set; }
        public double Weight { get; set; }
        public int StorageDays { get; set; }
    }
    public class ShipmentDetails : Shipment
    {
        public bool ValidateShipmentCode(string code)
        {
            if(code.Length != 7)
            {
                return false;
            }
            if (code[0..3] != "GC#" || !char.IsDigit(code[3]) || !char.IsDigit(code[4]) || !char.IsDigit(code[5]) || !char.IsDigit(code[6]))
            {
                return false;
            }
            return true;
        }
        public double CalculateTotalCost()
        {
            double rate = 0;

            if(TransportMode == "Sea")
            {
                rate = 15;
            }
            if(TransportMode == "Air")
            {
                rate = 50;
            }
            if(TransportMode == "Land")
            {
                rate = 25;
            }

            double total = (Weight * rate) + Math.Sqrt(StorageDays);
            return Math.Round(total, 2, MidpointRounding.AwayFromZero);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            ShipmentDetails shipment = new ShipmentDetails();

            shipment.ShipmentCode = "GC#1001";

            if (!shipment.ValidateShipmentCode(shipment.ShipmentCode))
            {
                Console.WriteLine("Invalid shipment code");
                return;
            }

            shipment.TransportMode = "Air";
            shipment.Weight = 10;
            shipment.StorageDays = 16;

            double cost = shipment.CalculateTotalCost();

            Console.WriteLine($"The total shipping cost is {cost:F2}");
        }
    }
}
