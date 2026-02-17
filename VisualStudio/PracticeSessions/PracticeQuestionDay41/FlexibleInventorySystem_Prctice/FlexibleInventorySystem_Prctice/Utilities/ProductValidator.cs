using System;
using FlexibleInventorySystem_Practice.Models;

namespace FlexibleInventorySystem_Practice.Utilities
{
    /// <summary>
    /// Validation helper class
    /// </summary>
    public static class ProductValidator
    {
        /// <summary>
        /// Validate product data
        /// Check:
        /// - ID not null/empty
        /// - Name not null/empty
        /// - Price > 0
        /// - Quantity >= 0
        /// </summary>
        public static bool ValidateProduct(Product product, out string errorMessage)
        {
            if (product == null)
            {
                errorMessage = "Product cannot be null.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(product.Id))
            {
                errorMessage = "Product ID cannot be null or empty.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                errorMessage = "Product Name cannot be null or empty.";
                return false;
            }
            if (product.Price <= 0)
            {
                errorMessage = "Product Price must be greater than 0.";
                return false;
            }
            if (product.Quantity < 0)
            {
                errorMessage = "Product Quantity cannot be negative.";
                return false;
            }
            errorMessage = null;
            return true;
        }

        /// <summary>
        /// Validate electronic product specific rules
        /// </summary>
        public static bool ValidateElectronicProduct(ElectronicProduct product, out string errorMessage)
        {
            if (!ValidateProduct(product, out errorMessage))
                return false;

            if (string.IsNullOrWhiteSpace(product.Brand))
            {
                errorMessage = "Brand cannot be null or empty.";
                return false;
            }
            if (product.WarrantyMonths < 0)
            {
                errorMessage = "Warranty months cannot be negative.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(product.Voltage))
            {
                errorMessage = "Voltage cannot be null or empty.";
                return false;
            }
            errorMessage = null;
            return true;
        }

        /// <summary>
        /// Validate grocery product specific rules
        /// </summary>
        public static bool ValidateGroceryProduct(GroceryProduct product, out string errorMessage)
        {
            if (!ValidateProduct(product, out errorMessage))
                return false;

            if (product.ExpiryDate <= DateTime.Now)
            {
                errorMessage = "Expiry date must be in the future.";
                return false;
            }
            if (product.Weight <= 0)
            {
                errorMessage = "Weight must be greater than 0.";
                return false;
            }
            errorMessage = null;
            return true;
        }

        /// <summary>
        /// Validate clothing product specific rules
        /// </summary>
        public static bool ValidateClothingProduct(ClothingProduct product, out string errorMessage)
        {
            if (!ValidateProduct(product, out errorMessage))
                return false;

            if (string.IsNullOrWhiteSpace(product.Size))
            {
                errorMessage = "Size cannot be null or empty.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(product.Color))
            {
                errorMessage = "Color cannot be null or empty.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(product.Material))
            {
                errorMessage = "Material cannot be null or empty.";
                return false;
            }
            errorMessage = null;
            return true;
        }
    }
}
