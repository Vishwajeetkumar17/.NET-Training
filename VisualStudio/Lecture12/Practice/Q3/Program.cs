using System;
using System.Collections.Generic;

namespace Q3
{
    /// <summary>
    /// Acts as the entry point for calculating the final bill amount
    /// by applying category-wise tax rates on commodities.
    /// </summary>
    public class Program
    {
        #region Application Entry Point

        // Entry point of the application
        static void Main()
        {
            var commodities = new List<Commodity>()
            {
                new Commodity(CommodityCategory.Furniture, "Bed", 2, 50000),
                new Commodity(CommodityCategory.Grocery, "Flour", 5, 80),
                new Commodity(CommodityCategory.Service, "Insurance", 8, 8500)
            };

            var prepareBill = new PrepareBill();

            prepareBill.SetTaxRates(CommodityCategory.Furniture, 18);
            prepareBill.SetTaxRates(CommodityCategory.Grocery, 5);
            prepareBill.SetTaxRates(CommodityCategory.Service, 12);

            var billAmount = prepareBill.CalculateBillAmount(commodities);
            Console.WriteLine(billAmount);
        }

        #endregion
    }
}
