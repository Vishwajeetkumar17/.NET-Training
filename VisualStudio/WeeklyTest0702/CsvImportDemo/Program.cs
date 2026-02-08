using System;
using System.Collections.Generic;
using System.IO;

namespace CsvImportDemo
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class RowError
    {
        public int RowNumber { get; set; }
        public string Reason { get; set; } = "";
    }

    public class ImportResult
    {
        public int InsertedCount { get; set; }
        public List<RowError> FailedRows { get; set; } = new();
    }
    public class CsvImporter
    {
        private readonly List<Product> _database = new();
        public ImportResult ImportProducts(string csvPath)
        {
            var result = new ImportResult();

            if (!File.Exists(csvPath))
                throw new FileNotFoundException("CSV file not found", csvPath);

            int rowNumber = 0;

            foreach (var line in File.ReadLines(csvPath))
            {
                rowNumber++;
                if (rowNumber == 1)
                    continue;

                try
                {
                    if (string.IsNullOrWhiteSpace(line))
                        throw new Exception("Empty row");

                    var parts = line.Split(',');

                    if (parts.Length != 4)
                        throw new Exception("Incorrect column count");

                    for (int i = 0; i < parts.Length; i++)
                        parts[i] = parts[i].Trim().Trim('"');

                    var product = new Product
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Price = decimal.Parse(parts[2]),
                        Quantity = int.Parse(parts[3])
                    };
                    if (string.IsNullOrWhiteSpace(product.Name))
                        throw new Exception("Name missing");

                    if (product.Price <= 0)
                        throw new Exception("Invalid price");

                    if (product.Quantity < 0)

                    _database.Add(product);
                    result.InsertedCount++;
                }
                catch (Exception ex)
                {
                    result.FailedRows.Add(new RowError
                    {
                        RowNumber = rowNumber,
                        Reason = ex.Message
                    });
                }
            }

            return result;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.Write("Enter CSV path(products.csv): ");
            string path = Console.ReadLine()!;

            var importer = new CsvImporter();
            try
            {
                var res = importer.ImportProducts(path);

                Console.WriteLine($"\nInserted Rows: {res.InsertedCount}");
                Console.WriteLine($"Failed Rows: {res.FailedRows.Count}");

                foreach (var err in res.FailedRows)
                {
                    Console.WriteLine($"Row {err.RowNumber}: {err.Reason}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal Error: " + ex.Message);
            }
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
