using System;

namespace ConstructionEstimateProblem7
{
    /// <summary>
    /// Represents construction estimate details
    /// including construction and site area.
    /// </summary>
    public class EstimateDetails
    {
        #region Properties

        // Gets or sets the construction area
        public float ConstructionArea { get; set; }

        // Gets or sets the site area
        public float SiteArea { get; set; }

        #endregion
    }

    /// <summary>
    /// Validates construction estimates and
    /// handles approval logic.
    /// </summary>
    public class Program
    {
        #region Validation Methods

        // Validates construction estimate against site area
        public EstimateDetails ValidateConstructionEstimate(float contructionArea, float siteArea)
        {
            if (contructionArea > siteArea)
            {
                throw new ConstructionEstimateException();
            }

            return new EstimateDetails
            {
                ConstructionArea = contructionArea,
                SiteArea = siteArea
            };
        }

        #endregion

        #region Application Entry Point

        // Entry point of the application
        static void Main(string[] args)
        {
            Program p = new Program();

            try
            {
                p.ValidateConstructionEstimate(15.5f, 34.6f);
                Console.WriteLine("Construction estimate is Approved");
            }
            catch (ConstructionEstimateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
