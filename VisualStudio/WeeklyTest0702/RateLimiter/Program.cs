using System;
using System.Collections.Generic;

namespace RateLimiter
{
    public class RateLimiter
    {
        private const int MAX_REQUESTS = 5;
        private static readonly TimeSpan WINDOW = TimeSpan.FromSeconds(10);

        private readonly Dictionary<string, Queue<DateTime>> _requests = new();

        private readonly object _lockObj = new object();

        public bool AllowRequest(string clientId, DateTime now)
        {
            lock (_lockObj)
            {
                if (!_requests.ContainsKey(clientId))
                    _requests[clientId] = new Queue<DateTime>();

                var queue = _requests[clientId];

                while (queue.Count > 0 && now - queue.Peek() > WINDOW)
                {
                    queue.Dequeue();
                }

                if (queue.Count >= MAX_REQUESTS)
                    return false;

                queue.Enqueue(now);
                return true;
            }
        }
    }
    class Program
    {
        static void Main()
        {
            var limiter = new RateLimiter();
            string client = "ClientA";

            Console.WriteLine("Sending 6 requests quickly:");

            for (int i = 1; i <= 6; i++)
            {
                bool allowed = limiter.AllowRequest(client, DateTime.UtcNow);
                Console.WriteLine($"Request {i}: {allowed}");
            }

            Console.WriteLine("\nWaiting 11 seconds...");
            System.Threading.Thread.Sleep(11000);

            bool afterWindow = limiter.AllowRequest(client, DateTime.UtcNow);
            Console.WriteLine($"Request after window: {afterWindow}");
        }
    }
}
