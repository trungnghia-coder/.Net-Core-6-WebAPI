using System.ComponentModel.DataAnnotations;

namespace WebApiNet.Models
{
    public class CategoryModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
