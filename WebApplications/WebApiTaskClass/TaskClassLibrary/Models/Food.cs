using System;
using System.Collections.Generic;

namespace TaskClassLibrary.Models;

public partial class Food
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Quantity { get; set; } = null!;
}
