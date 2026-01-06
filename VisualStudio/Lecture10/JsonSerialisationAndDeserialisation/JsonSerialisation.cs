using System;
using System.Text.Json;

namespace JsonSerialisationAndDeserialisation
{
    public class JsonSerialisation
    {
        public string Name { get; set; }
        public int Age { get; set; }
        static void Main(string[] args)
        {
            JsonSerialisation js = new JsonSerialisation { Name = "John Doe", Age = 30 };

            string jsonString = JsonSerializer.Serialize(js);

            Console.WriteLine(jsonString);     
        }
    }
}
