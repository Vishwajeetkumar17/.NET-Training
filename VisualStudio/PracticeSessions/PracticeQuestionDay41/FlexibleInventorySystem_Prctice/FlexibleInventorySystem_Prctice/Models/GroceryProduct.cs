using FlexibleInventorySystem_Practice.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Models
{
    /// <summary>
    /// TODO: Implement grocery product class
    /// </summary>
    public class GroceryProduct : Product
    {
        // TODO: Add these properties
        // - ExpiryDate (DateTime)
        public DateTime ExpiryDate { get; set; }
        // - IsPerishable (bool)
        public bool IsPerishable { get; set; }
        // - Weight (double)
        public double Weight { get; set; }
        // - StorageTemperature (string) - e.g., "Room temperature", "Refrigerated", "Frozen"
        public string StorageTemperature { get; set; } = string.Empty;

        /// <summary>
        /// TODO: Override GetProductDetails for grocery items
        /// Include expiry information
        /// </summary>
        public override string GetProductDetails()
        {
            // TODO: Implement
            return $"Name: {Name}, Price: {Price}, Quantity: {Quantity}, Expiry: {ExpiryDate:yyyy-MM-dd}, Perishable: {IsPerishable}, Weight: {Weight}kg, Storage: {StorageTemperature}";
        }

        /// <summary>
        /// TODO: Check if product is expired
        /// </summary>
        public bool IsExpired()
        {
            // TODO: Compare ExpiryDate with current date
            return ExpiryDate < DateTime.Now;
        }

        /// <summary>
        /// TODO: Calculate days until expiry
        /// Return negative if expired
        /// </summary>
        public int DaysUntilExpiry()
        {
            // TODO: Calculate days difference
            return (ExpiryDate - DateTime.Now).Days;
        }

        /// <summary>
        /// TODO: Override CalculateValue to apply discount for near-expiry items
        /// Apply 20% discount if within 3 days of expiry
        /// </summary>
        public override decimal CalculateValue()
        {
            // TODO: Apply discount logic if near expiry
            decimal discountedPrice = Price;
            int daysToExpiry = (ExpiryDate - DateTime.Now).Days;
            if (daysToExpiry >= 0 && daysToExpiry <= 3)
            {
                discountedPrice = Price * 0.80m;
            }
            return discountedPrice * Quantity;
        }
    }
}
