using System.ComponentModel.DataAnnotations;

namespace MyAPINetCore.Models
{
    public class LogInModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
