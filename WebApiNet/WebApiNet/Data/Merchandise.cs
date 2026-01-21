using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiNet.Data
{
    [Table("Merchandise")]
    public class Merchandise
    {
        [Key]
        public Guid MerchandiseId { get; set; }

        [Required]
        [MaxLength(100)]
        public string MerchandiseName { get; set; }

        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public byte Discount { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public ICollection<OrderDetail> OrderDetails
        {
            get; set;
        }

        public Merchandise()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
}
