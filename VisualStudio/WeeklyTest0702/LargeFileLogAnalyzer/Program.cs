using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace LargeFileLogAnalyzer
{
    public class ErrorSummary
    {
        public string Code { get; set; } = "";
        public int Count { get; set; }
    }
    public class Analyzer
    {
        private static readonly Regex ErrorRegex =
            new Regex(@"ERR\d+", RegexOptions.Compiled);

        public IEnumerable<ErrorSummary> GetTopErrors(string filePath, int topN)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Log file not found", filePath);

            var counts = new Dictionary<string, int>();

            foreach (var line in File.ReadLines(filePath))
            {
                foreach (Match match in ErrorRegex.Matches(line))
                {
                    var code = match.Value;

                    counts.TryGetValue(code, out int current);
                    counts[code] = current + 1;
                }
            }

            return counts
                .OrderByDescending(x => x.Value)
                .Take(topN)
                .Select(x => new ErrorSummary
                {
                    Code = x.Key,
                    Count = x.Value
                });
        }
    }
    class Program
    {
        static void Main()
        {
            try
            {
                var analyzer = new Analyzer();
                string path = "sample.log";
                var results = analyzer.GetTopErrors(path, 3);

                Console.WriteLine("Top Errors:\n");
                foreach (var r in results)
                {
                    Console.WriteLine($"{r.Code} -> {r.Count}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
