using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Food
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Quantity { get; set; } = string.Empty;
    }
}
