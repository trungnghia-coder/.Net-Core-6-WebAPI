using Microsoft.AspNetCore.Identity;

namespace MyAPINetCore.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FistName { get; set; } = null!;
        public string LastName { get; set; } = null!;

    }
}
