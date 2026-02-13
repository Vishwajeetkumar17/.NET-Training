namespace PracticeQuestionDay38
{
    public class Program
    {
        static Dictionary<string, int> ConsolidateCart(List<(string sku, int qty)> list)
        {
            var skuQty = new Dictionary<string, int>();
            foreach (var (sku, qty) in list)
            {
                if (qty <= 0)
                    continue;
                if (skuQty.ContainsKey(sku))
                {
                    skuQty[sku] += qty;
                }
                else
                {
                    skuQty[sku] = qty;
                }
            }
            return skuQty;

            //return list.Where(s => s.qty > 0).GroupBy(s => s.sku).ToDictionary(g => g.Key,g => g.Sum(x => x.qty));
        }

        static List<int> GetFirstUniqueEntries(List<int> list)
        {
            var seen = new HashSet<int>();
            var firstOcc = new List<int>();
            foreach (var id in list)
            {
                if (seen.Add(id))
                {
                    firstOcc.Add(id);
                }
            }
            return firstOcc;

            //return list.Distinct().ToList();
        }

        static List<(string name, int score)> GetTopK(List<(string name, int score)> players, int k)
        {
            return players.OrderByDescending(p => p.score).ThenBy(p => p.name).Take(k).ToList();
        }

        static int CountPeakRegularTickets(Queue<(TimeSpan entryTime, string ticketType)> q)
        {
            int count = 0;
            TimeSpan start = new TimeSpan(8, 0, 0);
            TimeSpan end = new TimeSpan(10, 0, 0);
            while (q.Count > 0)
            {
                var (time, type) = q.Dequeue();
                if (string.IsNullOrWhiteSpace(type))
                    continue;
                if (type == "Regular" && time >= start && time <= end)
                {
                    count++;
                }
            }
            return count;

            //return q.Count(x =>x.ticketType == "Regular" && x.entryTime >= start && x.entryTime <= end);
        }

        static string ProcessEditorOps(List<string> ops)
        {
            var stack = new Stack<string>();
            foreach (var op in ops)
            {
                if (op.StartsWith("TYPE "))
                {
                    string word = op.Substring(5);
                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        stack.Push(word);
                    }
                }
                else if (op == "UNDO")
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
            }
            return string.Join(" ", stack.Reverse());
        }

        static List<int> MergeSorted(List<int> list1, List<int> list2)
        {
            var merged = new List<int>(list1.Count + list2.Count);
            int i = 0, j = 0;
            while (i < list1.Count && j < list2.Count)
            {
                if (list1[i] <= list2[j])
                {
                    merged.Add(list1[i]);
                    i++;
                }
                else
                {
                    merged.Add(list2[j]);
                    j++;
                }
            }
            while (i < list1.Count)
            {
                merged.Add(list1[i]);
                i++;
            }
            while (j < list1.Count)
            {
                merged.Add(list2[j]);
                j++;
            }
            return merged;

            //return list1.Concat(list2).OrderBy(x => x).ToList();
        }

        static Dictionary<string, decimal> ComputeSpend(List<(string category, decimal amount)> txns)
        {
            var spendByCategory = new Dictionary<string, decimal>();
            foreach (var (category, amount) in txns)
            {
                if (amount >= 0)
                    continue;
                decimal spend = Math.Abs(amount);
                if (spendByCategory.ContainsKey(category))
                {
                    spendByCategory[category] += spend;
                }
                else
                {
                    spendByCategory[category] = spend;
                }
            }
            return spendByCategory;

            //return txns.Where(t => t.amount < 0).GroupBy(t => t.category).ToDictionary(g => g.Key, g => g.Sum(t => Math.Abs(t.amount)));
        }

        static List<string> FindDuplicates(List<string> serials)
        {
            var seen = new HashSet<string>();
            var added = new HashSet<string>();
            var duplicates = new List<string>();
            foreach (var serial in serials)
            {
                if (!seen.Add(serial))
                {
                    if (added.Add(serial))
                    {
                        duplicates.Add(serial);
                    }
                }
            }
            return duplicates;

            //return serials.GroupBy(s => s).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
        }

        static List<int> AllocateSeats(int n, List<int> alreadyBooked, int requestCount)
        {
            var available = new SortedSet<int>();
            for (int i = 1; i <= n; i++)
            {
                available.Add(i);
            }
            foreach (var seat in alreadyBooked)
            {
                available.Remove(seat);
            }
            var allocatedSeats = new List<int>();
            for (int i = 0; i < requestCount; i++)
            {
                if (available.Count > 0)
                {
                    int seat = available.Min;
                    allocatedSeats.Add(seat);
                    available.Remove(seat);
                }
                else
                {
                    allocatedSeats.Add(-1);
                }
            }
            return allocatedSeats;
        }

        static string MostFrequentCode(List<string> codes)
        {
            var freq = new Dictionary<string, int>();
            foreach (var code in codes)
            {
                if (string.IsNullOrWhiteSpace(code))
                    continue;
                if (freq.ContainsKey(code))
                    freq[code]++;
                else
                    freq[code] = 1;
            }
            string result = null;
            int maxCount = 0;
            foreach (var kv in freq)
            {
                if (kv.Value > maxCount ||
                   (kv.Value == maxCount &&
                    string.Compare(kv.Key, result) < 0))
                {
                    result = kv.Key;
                    maxCount = kv.Value;
                }
            }
            return result;

            //return codes.Where(c => !string.IsNullOrWhiteSpace(c)).GroupBy(c => c).OrderByDescending(g => g.Count()).ThenBy(g => g.Key)
            //.Select(g => g.Key).FirstOrDefault();
        }
        static void Main(string[] args)
        {
            // 1. E-Commerce Cart Consolidation
            //var list = new List<(string sku, int qty)>{
            //("A101", 2),
            //("B205", 1),
            //("A101", 3),
            //("C111", -1)
            //};
            //var result = ConsolidateCart(list);
            //foreach (var kv in result)
            //{
            //    Console.WriteLine($"{kv.Key}: {kv.Value}");
            //}


            // 2. Attendance – First Unique Entry
            //var list = new List<int> { 10, 20, 10, 30, 20, 40 };
            //var result = GetFirstUniqueEntries(list);
            //Console.WriteLine(string.Join(", ", result));


            // 3. Leaderboard – Top K Scores
            //var players = new List<(string name, int score)>
            //{
            //    ("Raj", 80),
            //    ("Anu", 95),
            //    ("Vikram", 95),
            //    ("Meena", 70)
            //};
            //int k = 3;
            //var result = GetTopK(players, k);
            //foreach (var p in result)
            //{
            //    Console.WriteLine($"{p.name}: {p.score}");
            //}


            // 4. Metro Ticketing – Peak Hour Count
            //var q = new Queue<(TimeSpan, string)>();
            //q.Enqueue((new TimeSpan(7, 50, 0), "Regular"));
            //q.Enqueue((new TimeSpan(8, 15, 0), "Regular"));
            //q.Enqueue((new TimeSpan(9, 30, 0), "Student"));
            //q.Enqueue((new TimeSpan(10, 0, 0), "Regular"));
            //q.Enqueue((new TimeSpan(10, 5, 0), "Regular"));
            //int result = CountPeakRegularTickets(q);
            //Console.WriteLine(result);


            // 5. Undo Feature – Text Editor
            //var ops = new List<string> { "TYPE Hello", "TYPE World", "UNDO", "TYPE CSharp" };
            //string result = ProcessEditorOps(ops);
            //Console.WriteLine(result);


            // 6. Customer Support – Merge Two Ticket Streams
            //var list1 = new List<int> { 1, 4, 7 };
            //var list2 = new List<int> { 2, 3, 8 };
            //var result = MergeSorted(list1, list2);
            //Console.WriteLine(string.Join(", ", result));


            // 7. Bank Statement – Spend by Category
            //var txns = new List<(string, decimal)>
            //{
            //    ("Food", -200),
            //    ("Fuel", -500),
            //    ("Food", -50),
            //    ("Salary", 1000)
            //};
            //var result = ComputeSpend(txns);
            //foreach (var kv in result)
            //{
            //    Console.WriteLine($"{kv.Key}: {kv.Value}");
            //}


            // 8. Inventory – Detect Duplicate Serials
            //var serials = new List<string> { "S1", "S2", "S1", "S3", "S2", "S2" };
            //var result = FindDuplicates(serials);
            //Console.WriteLine(string.Join(", ", result));


            // 9. Movie Booking – Seat Allocation
            //int n = 5;
            //var alreadyBooked = new List<int> { 2, 4 };
            //int requestCount = 5;
            //var result = AllocateSeats(n, alreadyBooked, requestCount);
            //Console.WriteLine(string.Join(", ", result));


            // 10. Log Analyzer – Most Frequent Error Code
            //var codes = new List<string> { "E02", "E01", "E02", "E01", "E03" };
            //string result = MostFrequentCode(codes);
            //Console.WriteLine(result);
        }
    }
}
