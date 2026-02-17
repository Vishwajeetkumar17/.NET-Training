using FlexibleInventorySystem_Practice.Interfaces;
using FlexibleInventorySystem_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Services
{
    public class InventoryManager : IInventoryOperations, IReportGenerator
    {
        private readonly List<Product> _products;

        public InventoryManager()
        {
            _products = new List<Product>();
        }

        public bool AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            _products.Add(product);
            return true;
        }

        public Product? FindProduct(string productId)
        {
            return _products.FirstOrDefault(item => item.Id == productId);
        }

        public string GenerateCategorySummary()
        {
            var summary = _products
                .GroupBy(p => p.Category)
                .Select(g => $"{g.Key}: {g.Count()} products")
                .ToList();
            return string.Join(Environment.NewLine, summary);
        }

        public string GenerateExpiryReport(int daysThreshold)
        {
            var now = DateTime.Now;
            var expiringProducts = _products
                .Where(p => p is GroceryProduct gp && (gp.ExpiryDate - now).TotalDays <= daysThreshold)
                .ToList();

            if (!expiringProducts.Any())
                return "No products expiring soon.";

            return string.Join(Environment.NewLine, expiringProducts.Select(p => p.ToString()));
        }

        public string GenerateInventoryReport()
        {
            if (!_products.Any())
                return "No products in inventory.";
            return string.Join(Environment.NewLine, _products.Select(p => p.ToString()));
        }

        public string GenerateValueReport()
        {
            decimal totalValue = _products.Sum(p => p.CalculateValue());
            return $"Total Inventory Value: {totalValue:C}";
        }

        public List<Product> GetLowStockProducts(int threshold)
        {
            return _products.Where(p => p.Quantity <= threshold).ToList();
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return _products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public decimal GetTotalInventoryValue()
        {
            return _products.Sum(p => p.CalculateValue());
        }

        public bool RemoveProduct(string productId)
        {
            var product = FindProduct(productId);
            if (product != null)
            {
                _products.Remove(product);
                return true;
            }
            return false;
        }

        // Implement all interface methods here

        // Additional methods for bonus features
        public IEnumerable<Product> SearchProducts(Func<Product, bool> predicate)
        {
            return _products.Where(predicate);
        }

        public bool UpdateQuantity(string productId, int newQuantity)
        {
            var product = FindProduct(productId);
            if (product != null)
            {
                product.Quantity = newQuantity;
                return true;
            }
            return false;
        }
    }
}
