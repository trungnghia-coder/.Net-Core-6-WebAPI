namespace WebApiNet.Data
{
    public enum OrderStatus
    {
        New = 0,
        Payment = 1,
        Complete = 2,
        Cancelled = -1
    }
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? OrderShip { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Receiver { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
}
