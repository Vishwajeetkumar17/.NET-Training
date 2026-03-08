using System;
using System.Collections.Generic;
using System.Linq;

namespace Four
{
    public interface IFinancialInstrument
    {
        string Symbol { get; }
        decimal CurrentPrice { get; }
        InstrumentType Type { get; }
    }

    public enum InstrumentType { Stock, Bond, Option, Future }

    // 1. Generic portfolio
    public class Portfolio<T> where T : IFinancialInstrument
    {
        private Dictionary<T, int> _holdings = new(); // Instrument -> Quantity

        // TODO: Buy instrument
        public void Buy(T instrument, int quantity, decimal price)
        {
            // Validate: quantity > 0, price > 0
            // Add to holdings or update quantity

            if (quantity <= 0 || price <= 0)
                throw new ArgumentException("Invalid quantity or price");

            if (_holdings.ContainsKey(instrument))
                _holdings[instrument] += quantity;
            else
                _holdings[instrument] = quantity;
        }

        // TODO: Sell instrument
        public decimal? Sell(T instrument, int quantity, decimal currentPrice)
        {
            // Validate: enough quantity
            // Remove/update holdings
            // Return proceeds (quantity * currentPrice)

            if (!_holdings.ContainsKey(instrument) || _holdings[instrument] < quantity)
                return null;

            _holdings[instrument] -= quantity;

            if (_holdings[instrument] == 0)
                _holdings.Remove(instrument);

            return quantity * currentPrice;
        }

        // TODO: Calculate total value
        public decimal CalculateTotalValue()
        {
            // Sum of (quantity * currentPrice) for all holdings

            return _holdings.Sum(h => h.Key.CurrentPrice * h.Value);
        }

        // TODO: Get top performing instrument
        public (T instrument, decimal returnPercentage)? GetTopPerformer(
            Dictionary<T, decimal> purchasePrices)
        {
            // Calculate return percentage for each
            // Return highest performer

            if (!_holdings.Any())
                return null;

            var performances = _holdings
                .Where(h => purchasePrices.ContainsKey(h.Key))
                .Select(h =>
                {
                    decimal buyPrice = purchasePrices[h.Key];
                    decimal ret = ((h.Key.CurrentPrice - buyPrice) / buyPrice) * 100;
                    return (instrument: h.Key, returnPercentage: ret);
                });

            return performances.OrderByDescending(p => p.returnPercentage).FirstOrDefault();
        }

        public IEnumerable<T> GetInstruments()
        {
            return _holdings.Keys;
        }
    }

    // 2. Specialized instruments
    public class Stock : IFinancialInstrument
    {
        public string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }
        public InstrumentType Type => InstrumentType.Stock;
        public string CompanyName { get; set; }
        public decimal DividendYield { get; set; }
    }

    public class Bond : IFinancialInstrument
    {
        public string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }
        public InstrumentType Type => InstrumentType.Bond;
        public DateTime MaturityDate { get; set; }
        public decimal CouponRate { get; set; }
    }

    // 3. Generic trading strategy
    public class TradingStrategy<T> where T : IFinancialInstrument
    {
        // TODO: Execute strategy on portfolio
        public void Execute(Portfolio<T> portfolio,
            Func<T, bool> buyCondition,
            Func<T, bool> sellCondition)
        {
            // For each instrument in market data
            // Apply buy/sell conditions
            // Execute trades

            foreach (var instrument in portfolio.GetInstruments().ToList())
            {
                if (sellCondition(instrument))
                    portfolio.Sell(instrument, 1, instrument.CurrentPrice);

                if (buyCondition(instrument))
                    portfolio.Buy(instrument, 1, instrument.CurrentPrice);
            }
        }

        // TODO: Calculate risk metrics
        public Dictionary<string, decimal> CalculateRiskMetrics(IEnumerable<T> instruments)
        {
            // Return: Volatility, Beta, Sharpe Ratio

            var prices = instruments.Select(i => i.CurrentPrice).ToList();
            decimal avg = prices.Average();

            decimal variance = prices.Sum(p => (p - avg) * (p - avg)) / prices.Count;
            decimal volatility = (decimal)Math.Sqrt((double)variance);

            decimal beta = avg == 0 ? 0 : volatility / avg;
            decimal sharpe = volatility == 0 ? 0 : avg / volatility;

            return new Dictionary<string, decimal>
            {
                {"Volatility", volatility},
                {"Beta", beta},
                {"Sharpe Ratio", sharpe}
            };
        }
    }

    // 4. Price history with generics
    public class PriceHistory<T> where T : IFinancialInstrument
    {
        private Dictionary<T, List<(DateTime, decimal)>> _history = new();

        // TODO: Add price point
        public void AddPrice(T instrument, DateTime timestamp, decimal price)
        {
            // Add to history

            if (!_history.ContainsKey(instrument))
                _history[instrument] = new List<(DateTime, decimal)>();

            _history[instrument].Add((timestamp, price));
        }

        // TODO: Get moving average
        public decimal? GetMovingAverage(T instrument, int days)
        {
            // Calculate simple moving average

            if (!_history.ContainsKey(instrument))
                return null;

            var data = _history[instrument].OrderByDescending(x => x.Item1).Take(days).Select(x => x.Item2).ToList();

            if (!data.Any())
                return null;

            return data.Average();
        }

        // TODO: Detect trends
        public Trend DetectTrend(T instrument, int period)
        {
            // Return: Upward, Downward, Sideways

            if (!_history.ContainsKey(instrument))
                return Trend.Sideways;

            var data = _history[instrument].OrderBy(x => x.Item1).TakeLast(period).Select(x => x.Item2).ToList();

            if (data.Count < 2)
                return Trend.Sideways;

            if (data.Last() > data.First())
                return Trend.Upward;
            if (data.Last() < data.First())
                return Trend.Downward;

            return Trend.Sideways;
        }
    }

    public enum Trend { Upward, Downward, Sideways }

    // 5. TEST SCENARIO: Trading simulation
    // a) Create portfolio with mixed instruments
    // b) Implement buy/sell logic
    // c) Create trading strategy with lambda conditions
    // d) Track price history
    // e) Demonstrate:
    //    - Portfolio rebalancing
    //    - Risk calculation
    //    - Trend detection
    //    - Performance comparison

    public class Program
    {
        public static void Main()
        {
            var s = new Stock { Symbol = "AAPL", CurrentPrice = 150, CompanyName = "Apple" };
            var b = new Bond { Symbol = "US10Y", CurrentPrice = 95, CouponRate = 2.5m };

            var portfolio = new Portfolio<IFinancialInstrument>();
            portfolio.Buy(s, 5, s.CurrentPrice);
            portfolio.Buy(b, 3, b.CurrentPrice);

            Console.WriteLine(portfolio.CalculateTotalValue());

            var strategy = new TradingStrategy<IFinancialInstrument>();
            strategy.Execute(
                portfolio,
                i => i.CurrentPrice < 120,
                i => i.CurrentPrice > 140
            );

            var risk = strategy.CalculateRiskMetrics(portfolio.GetInstruments());
            foreach (var r in risk)
                Console.WriteLine($"{r.Key}:{r.Value}");

            var history = new PriceHistory<IFinancialInstrument>();
            history.AddPrice(s, DateTime.Now.AddDays(-2), 140);
            history.AddPrice(s, DateTime.Now.AddDays(-1), 145);
            history.AddPrice(s, DateTime.Now, 150);

            Console.WriteLine(history.GetMovingAverage(s, 3));
            Console.WriteLine(history.DetectTrend(s, 3));

            var purchase = new Dictionary<IFinancialInstrument, decimal>{{s,130},{b,90}};

            var top = portfolio.GetTopPerformer(purchase);
            if (top != null)
                Console.WriteLine($"{top?.instrument.Symbol} {top?.returnPercentage}");
        }
    }
}
