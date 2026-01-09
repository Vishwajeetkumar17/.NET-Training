namespace Q3
{
    /// <summary>
    /// Represents a commodity item with category, name,
    /// quantity, and unit price details.
    /// </summary>
    public class Commodity
    {
        #region Properties

        // Gets or sets the commodity category
        public CommodityCategory Category { get; set; }

        // Gets or sets the commodity name
        public string CommodityName { get; set; }

        // Gets or sets the quantity of the commodity
        public int CommodityQuantity { get; set; }

        // Gets or sets the unit price of the commodity
        public double CommodityPrice { get; set; }

        #endregion

        #region Constructors

        // Initializes a new Commodity instance
        public Commodity(
            CommodityCategory category,
            string commodityName,
            int commodityQuantity,
            double comodityPrice)
        {
            Category = category;
            CommodityName = commodityName;
            CommodityQuantity = commodityQuantity;
            CommodityPrice = comodityPrice;
        }

        #endregion
    }
}
