namespace E_CommerceOrderPrioritySystem09
{
    public class Order
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public int OrderAmount { get; set; }

        public Order(string orderId, string customerName, int orderAmount)
        {
            if (orderAmount <= 0)
                throw new InvalidOrderAmountException("Invalid Order Amount");

            OrderId = orderId;
            CustomerName = customerName;
            OrderAmount = orderAmount;
        }
    }
}
