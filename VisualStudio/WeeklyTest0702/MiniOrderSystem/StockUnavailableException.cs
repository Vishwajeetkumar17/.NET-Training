
namespace MiniOrderSystem
{
    [Serializable]
    public class StockUnavailableException : Exception
    {
        public StockUnavailableException(string? message) : base(message) { }
    }

    public class OrderException : Exception
    {
        public OrderException(string msg) : base(msg) { }
    }

    public class CouponInvalidException : OrderException
    {
        public CouponInvalidException(string msg) : base(msg) { }
    }

    public class PaymentFailedException : OrderException
    {
        public PaymentFailedException(string msg) : base(msg) { }
    }
}