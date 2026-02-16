namespace E_CommerceOrderPrioritySystem09
{
    public class OrderUtility
    {
        private SortedDictionary<int, List<Order>> orders = new SortedDictionary<int, List<Order>>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        public void AddOrder(Order order)
        {
            if (!orders.ContainsKey(order.OrderAmount))
                orders[order.OrderAmount] = new List<Order>();

            orders[order.OrderAmount].Add(order);
        }

        public void DisplayOrders()
        {
            foreach (var entry in orders)
            {
                foreach (var order in entry.Value)
                {
                    Console.WriteLine($"Details: {order.OrderId} {order.CustomerName} {order.OrderAmount}");
                }
            }
        }

        public void UpdateOrder(string orderId, int newAmount)
        {
            if (newAmount <= 0)
                throw new InvalidOrderAmountException("Invalid Order Amount");

            foreach (var entry in orders)
            {
                foreach (var order in entry.Value)
                {
                    if (order.OrderId.Equals(orderId))
                    {
                        entry.Value.Remove(order);

                        order.OrderAmount = newAmount;

                        if (!orders.ContainsKey(newAmount))
                            orders[newAmount] = new List<Order>();

                        orders[newAmount].Add(order);
                        return;
                    }
                }
            }

            throw new OrderNotFoundException("Order Not Found");
        }
    }
}
