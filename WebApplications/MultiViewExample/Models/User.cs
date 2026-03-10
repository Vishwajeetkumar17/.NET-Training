using System.Text.Json.Serialization;

namespace MultiViewExample.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}