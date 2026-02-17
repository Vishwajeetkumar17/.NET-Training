using FlexibleInventorySystem_Practice.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FlexibleInventorySystem_Practice.Utilities
{
    public static class FileHandler
    {
        public static void SaveProductsToFile(string filePath, List<Product> products)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                // To support polymorphic serialization for derived product types
                IncludeFields = true,
                PropertyNameCaseInsensitive = true
            };
            string json = JsonSerializer.Serialize(products, products.GetType(), options);
            File.WriteAllText(filePath, json);
        }

        public static List<Product> LoadProductsFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<Product>();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            string json = File.ReadAllText(filePath);
            // You may need to use a custom converter for polymorphic deserialization
            return JsonSerializer.Deserialize<List<Product>>(json, options) ?? new List<Product>();
        }
    }
}
