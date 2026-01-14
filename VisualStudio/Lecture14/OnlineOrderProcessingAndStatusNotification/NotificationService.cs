namespace OnlineOrderProcessingAndStatusNotification
{
    public static class NotificationService
    {
        public static void CustomerNotification(
            Order order,
            OrderStatus oldStatus,
            OrderStatus newStatus)
        {
            Console.WriteLine(
                $"[Customer] {order.Customer.Name} | Order {order.Id}: {oldStatus} -> {newStatus}"
            );
        }

        public static void LogisticsNotification(
            Order order,
            OrderStatus oldStatus,
            OrderStatus newStatus)
        {
            if (newStatus == OrderStatus.Shipped)
            {
                Console.WriteLine(
                    $"[Logistics] Order {order.Id} dispatched for delivery"
                );
            }
        }
    }
}
