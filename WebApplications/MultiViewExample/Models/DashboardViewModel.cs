using System.Collections.Generic;

namespace MultiViewExample.Models
{
    public class DashboardViewModel
    {
        public UserDTO User { get; set; }
        public List<Order> Orders { get; set; }
    }
}