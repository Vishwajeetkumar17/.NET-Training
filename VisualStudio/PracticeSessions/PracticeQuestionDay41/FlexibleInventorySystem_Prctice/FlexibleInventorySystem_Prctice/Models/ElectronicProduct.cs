using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Models
{
    // Different Product Types

    /// <summary>
    /// TODO: Implement electronic product class
    /// </summary>
    public class ElectronicProduct : Product
    {
        // TODO: Add these properties
        // - Brand (string)
        public string Brand { get; set; } = string.Empty;
        // - WarrantyMonths (int)
        public int WarrantyMonths { get; set; }
        // - Voltage (string)
        public string Voltage { get; set; } = string.Empty;
        // - IsRefurbished (bool)
        public bool IsRefurbished { get; set; }

        /// <summary>
        /// TODO: Override GetProductDetails to include electronic specifics
        /// Format: "Brand: {Brand}, Model: {Name}, Warranty: {WarrantyMonths} months"
        /// </summary>
        public override string GetProductDetails()
        {
            // TODO: Implement
            return $"Brand: {Brand}, Model: {Name}, Warranty: {WarrantyMonths} months";
        }

        /// <summary>
        /// TODO: Calculate warranty expiration date
        /// </summary>
        public DateTime GetWarrantyExpiryDate()
        {
            // TODO: Return DateAdded.AddMonths(WarrantyMonths)
            return DateAdded.AddMonths(WarrantyMonths);
        }

        /// <summary>
        /// TODO: Check if warranty is still valid
        /// </summary>
        public bool IsWarrantyValid()
        {
            // Compare warranty expiry with current date
            return GetWarrantyExpiryDate() > DateTime.Now;
        }
    }
}
