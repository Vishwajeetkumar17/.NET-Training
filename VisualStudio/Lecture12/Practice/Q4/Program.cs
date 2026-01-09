using System;
using System.Collections.Generic;

namespace Q4
{
    /// <summary>
    /// Acts as the entry point for evaluating broadband plans
    /// and displaying eligible subscription plans.
    /// </summary>
    public class Program
    {
        #region Application Entry Point

        // Entry point of the application
        static void Main(string[] args)
        {
            var plans = new List<IBroadbandPlan>
            {
                new Black(true, 50),
                new Black(false, 10),
                new Gold(true, 30),
                new Black(true, 20),
                new Gold(false, 20),
            };

            var subscriptionPlans = new SubscribePlan(plans);
            var result = subscriptionPlans.GetSubscriptionPlan();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Item1}, {item.Item2}");
            }
        }

        #endregion
    }
}
