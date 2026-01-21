namespace WebApiNet.Data
{
    public class OrderDetail
    {
        public Guid MerchandiseId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public byte Discount { get; set; }

        //relationship
        public Merchandise Merchandise { get; set; }
        public Order Order { get; set; }
    }
}
