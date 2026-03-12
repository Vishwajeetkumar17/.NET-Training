using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskClassLibrary.Models;

public partial class Food
{
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Quantity { get; set; } = null!;
}
