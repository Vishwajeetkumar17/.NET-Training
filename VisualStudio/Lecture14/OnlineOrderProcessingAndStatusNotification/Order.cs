namespace OnlineOrderProcessingAndStatusNotification
{
    public class Order
    {
        public int Id { get; }
        public Customer Customer { get; }
        public OrderStatus CurrentStatus { get; private set; }

        private readonly List<OrderItem> items = new List<OrderItem>();
        private readonly List<OrderStatusLog> statusHistory = new List<OrderStatusLog>();

        public IReadOnlyList<OrderItem> Items => items.AsReadOnly();
        public IReadOnlyList<OrderStatusLog> StatusHistory => statusHistory.AsReadOnly();

        // Delegate (NOT event)
        public OrderStatusChangedHandler StatusChanged;

        public Order(int id, Customer customer)
        {
            Id = id;
            Customer = customer;
            CurrentStatus = OrderStatus.Created;
            statusHistory.Add(new OrderStatusLog(CurrentStatus));
        }

        public void AddItem(OrderItem item)
        {
            items.Add(item);
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.GetSubTotal();
            }
            return total;
        }

        public void ChangeStatus(OrderStatus newStatus)
        {
            ValidateStatusTransition(newStatus);

            OrderStatus oldStatus = CurrentStatus;
            CurrentStatus = newStatus;
            statusHistory.Add(new OrderStatusLog(newStatus));

            StatusChanged?.Invoke(this, oldStatus, newStatus);
        }

        private void ValidateStatusTransition(OrderStatus newStatus)
        {
            if (CurrentStatus == OrderStatus.Cancelled)
                throw new InvalidOperationException("Cancelled order cannot progress.");

            if (newStatus == OrderStatus.Packed && CurrentStatus != OrderStatus.Paid)
                throw new InvalidOperationException("Order must be Paid before Packing.");

            if (newStatus == OrderStatus.Shipped && CurrentStatus != OrderStatus.Packed)
                throw new InvalidOperationException("Order must be Packed before Shipping.");

            if (newStatus == OrderStatus.Delivered && CurrentStatus != OrderStatus.Shipped)
                throw new InvalidOperationException("Order must be Shipped before Delivery.");
        }
    }
}
