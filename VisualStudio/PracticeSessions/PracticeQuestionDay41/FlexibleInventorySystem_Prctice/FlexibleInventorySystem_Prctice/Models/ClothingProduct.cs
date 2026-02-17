using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Models
{

    /// <summary>
    /// TODO: Implement clothing product class
    /// </summary>
    public class ClothingProduct : Product
    {
        // TODO: Add these properties
        // - Size (string)
        public string Size { get; set; } = string.Empty;
        // - Color (string)
        public string Color { get; set; } = string.Empty;
        // - Material (string)
        public string Material { get; set; } = string.Empty;
        // - Gender (string) - "Men", "Women", "Unisex"
        public string Gender { get; set; } = string.Empty;
        // - Season (string) - "Summer", "Winter", "All-season"
        public string Season { get; set; } = string.Empty;

        /// <summary>
        /// TODO: Override GetProductDetails for clothing items
        /// </summary>
        public override string GetProductDetails()
        {
            // TODO: Return formatted string with size, color, material
            return $"Name: {Name}, Size: {Size}, Color: {Color}, Material: {Material}, Gender: {Gender}, Season: {Season}";
        }

        /// <summary>
        /// TODO: Check if size is available
        /// Valid sizes: XS, S, M, L, XL, XXL
        /// </summary>
        public bool IsValidSize()
        {
            // TODO: Validate size against allowed values
            List<string> sizes = new List<string>() { "XS", "S", "M", "L", "XL", "XXL" };
            if (!sizes.Contains(Size))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// TODO: Override CalculateValue to apply seasonal discount
        /// Apply 15% discount for off-season items
        /// </summary>
        public override decimal CalculateValue()
        {
            // TODO: Apply seasonal discount logic
            decimal discountedPrice = Price;
            if (Season != "All-season")
            {
                discountedPrice = Price * 0.85m;
            }
            return discountedPrice * Quantity;
        }
    }
}