using System;
using System.Collections.Generic;
using System.Linq;

namespace ParallelAggregationDemo
{
    public class Sale
    {
        public string Region { get; set; } = "";
        public string Category { get; set; } = "";
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
    public class AggregationResult
    {
        public Dictionary<string, decimal> TotalByRegion { get; set; } = new();
        public Dictionary<string, string> TopCategoryByRegion { get; set; } = new();
        public DateTime BestSalesDay { get; set; }
    }
    public class Aggregator
    {
        public AggregationResult Compute(List<Sale> sales)
        {
            var query = sales.AsParallel();
            var totalByRegion = query
                .GroupBy(s => s.Region)
                .Select(g => new
                {
                    Region = g.Key,
                    Total = g.Sum(x => x.Amount)
                })
                .ToDictionary(x => x.Region, x => x.Total);

            var topCategoryByRegion = query
                .GroupBy(s => s.Region)
                .Select(g => new
                {
                    Region = g.Key,
                    TopCategory = g.GroupBy(x => x.Category)
                                   .Select(c => new
                                   {
                                       Category = c.Key,
                                       Total = c.Sum(x => x.Amount)
                                   })
                                   .OrderByDescending(x => x.Total)
                                   .ThenBy(x => x.Category)
                                   .First().Category
                })
                .ToDictionary(x => x.Region, x => x.TopCategory);

            var bestDay = query
                .GroupBy(s => s.Date.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    Total = g.Sum(x => x.Amount)
                })
                .OrderByDescending(x => x.Total)
                .ThenBy(x => x.Date)
                .First().Date;

            return new AggregationResult
            {
                TotalByRegion = totalByRegion
                    .OrderBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value),

                TopCategoryByRegion = topCategoryByRegion
                    .OrderBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value),

                BestSalesDay = bestDay
            };
        }
    }
    class Program
    {
        static void Main()
        {
            var sales = new List<Sale>
            {
                new Sale { Region="East", Category="Tech", Amount=500, Date=DateTime.Parse("2024-01-01")},
                new Sale { Region="East", Category="Books", Amount=200, Date=DateTime.Parse("2024-01-02")},
                new Sale { Region="West", Category="Tech", Amount=700, Date=DateTime.Parse("2024-01-01")},
                new Sale { Region="West", Category="Clothes", Amount=300, Date=DateTime.Parse("2024-01-03")},
                new Sale { Region="East", Category="Tech", Amount=400, Date=DateTime.Parse("2024-01-01")}
            };
            var aggregator = new Aggregator();
            var result = aggregator.Compute(sales);

            Console.WriteLine("Total by Region:");
            foreach (var r in result.TotalByRegion)
                Console.WriteLine($"{r.Key} -> {r.Value}");

            Console.WriteLine("\nTop Category per Region:");
            foreach (var r in result.TopCategoryByRegion)
                Console.WriteLine($"{r.Key} -> {r.Value}");

            Console.WriteLine($"\nBest Sales Day: {result.BestSalesDay:d}");
        }
    }
}
