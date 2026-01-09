using System;

namespace Q4
{
    /// <summary>
    /// Represents the Gold broadband plan and
    /// calculates the final subscription amount.
    /// </summary>
    public class Gold : IBroadbandPlan
    {
        #region Fields

        // Indicates whether the subscription is valid
        private readonly bool _isSubscribedValid;

        // Stores the discount percentage
        private readonly int _discountPercentage;

        // Base amount for the Gold plan
        private const int PlanAmount = 1500;

        #endregion

        #region Constructors

        // Initializes the Gold plan with subscription and discount details
        public Gold(bool isSubscribedValid, int discountPercentage)
        {
            _isSubscribedValid = isSubscribedValid;

            if (discountPercentage < 0 || discountPercentage > 30)
            {
                throw new ArgumentOutOfRangeException("Discount Percentage is not Valid");
            }

            _discountPercentage = discountPercentage;
        }

        #endregion

        #region Public Methods

        // Calculates and returns the final plan amount
        public int GetBroadbandPlanAmount()
        {
            if (_isSubscribedValid)
            {
                return PlanAmount - (PlanAmount * _discountPercentage / 100);
            }

            return PlanAmount;
        }

        #endregion
    }
}
