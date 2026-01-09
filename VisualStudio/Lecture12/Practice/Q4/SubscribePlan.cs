using System;
using System.Collections.Generic;

namespace Q4
{
    /// <summary>
    /// Processes broadband plans and prepares
    /// subscription details for display.
    /// </summary>
    public class SubscribePlan
    {
        #region Fields

        // Stores the list of broadband plans
        private readonly IList<IBroadbandPlan> _broadbandPlans;

        #endregion

        #region Constructors

        // Initializes the SubscribePlan with available broadband plans
        public SubscribePlan(IList<IBroadbandPlan> broadbandPlans)
        {
            if (broadbandPlans == null)
            {
                throw new ArgumentNullException("You have no Broadband Plans");
            }

            _broadbandPlans = broadbandPlans;
        }

        #endregion

        #region Public Methods

        // Returns subscription plan name and amount details
        public IList<Tuple<string, int>> GetSubscriptionPlan()
        {
            if (_broadbandPlans == null)
            {
                throw new ArgumentNullException("Broadband plans are null");
            }

            var result = new List<Tuple<string, int>>();

            foreach (var plan in _broadbandPlans)
            {
                string planName = plan.GetType().Name;
                int amount = plan.GetBroadbandPlanAmount();
                result.Add(new Tuple<string, int>(planName, amount));
            }

            return result;
        }

        #endregion
    }
}
