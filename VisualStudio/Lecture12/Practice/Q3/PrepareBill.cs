using System;
using System.Collections.Generic;

namespace Q3
{
    /// <summary>
    /// Handles tax configuration and calculates the final bill amount
    /// for a list of commodities based on their categories.
    /// </summary>
    public class PrepareBill
    {
        #region Fields

        // Stores tax rates mapped to commodity categories
        private readonly IDictionary<CommodityCategory, double> _taxRates;

        #endregion

        #region Constructors

        // Initializes the tax rate collection
        public PrepareBill()
        {
            _taxRates = new Dictionary<CommodityCategory, double>();
        }

        #endregion

        #region Public Methods

        // Sets tax rate for a given commodity category
        public void SetTaxRates(CommodityCategory category, double taxRate)
        {
            if (!_taxRates.ContainsKey(category))
            {
                _taxRates[category] = taxRate;
            }
        }

        // Calculates and returns the total bill amount including tax
        public double CalculateBillAmount(IList<Commodity> items)
        {
            double total = 0;

            foreach (var item in items)
            {
                if (!_taxRates.ContainsKey(item.Category))
                {
                    throw new Exception("Tax rate not found for category");
                }

                double tax = _taxRates[item.Category];
                double price = item.CommodityPrice * item.CommodityQuantity;

                total += price + (price * tax / 100);
            }

            return total;
        }

        #endregion
    }
}
