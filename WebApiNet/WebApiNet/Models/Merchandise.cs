namespace WebApiNet.Models
{
    public class MerchandiseVM
    {
        public string MerchandiseName { get; set; }
        public double Price { get; set; }

    }

    public class Merchandise : MerchandiseVM
    {
        public Guid MerchandiseId { get; set; }
    }

    public class MerchandiseModel
    {
        public Guid MerchandiseId { get; set; }
        public string MerchandiseName { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
    }
}
