using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JsonSerialisationAndDeserialisation
{
    internal class JsonDeserialisation
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public static void Main()
        {
            string jsonString = @"{""Name"":""John Doe"",""Age"":30,""City"":""New York""}";

            JsonDeserialisation jd = JsonSerializer.Deserialize<JsonDeserialisation>(jsonString);

            Console.WriteLine($"Name: {jd.Name}, Age: {jd.Age}, City: {jd.City}");

        }
    }
}
