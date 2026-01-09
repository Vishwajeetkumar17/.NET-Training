using System;

namespace Q4
{
    /// <summary>
    /// Represents the Black broadband plan and
    /// calculates the final subscription amount.
    /// </summary>
    public class Black : IBroadbandPlan
    {
        #region Fields

        // Indicates whether the subscription is valid
        private readonly bool _isSubcriptionValid;

        // Stores the discount percentage
        private readonly int _discountPercentage;

        // Base amount for the Black plan
        private const int PlanAmount = 3000;

        #endregion

        #region Constructors

        // Initializes the Black plan with subscription and discount details
        public Black(bool isSubscribedValid, int discountPercentage)
        {
            _isSubcriptionValid = isSubscribedValid;

            if (discountPercentage < 0 || discountPercentage > 50)
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
            if (_isSubcriptionValid)
            {
                return PlanAmount - (PlanAmount * _discountPercentage / 100);
            }

            return PlanAmount;
        }

        #endregion
    }
}
