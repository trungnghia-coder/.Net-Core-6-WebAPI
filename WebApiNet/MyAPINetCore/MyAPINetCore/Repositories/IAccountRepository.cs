using Microsoft.AspNetCore.Identity;
using MyAPINetCore.Models;

namespace MyAPINetCore.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> RegisterAsync(RegisterModel model);
        Task<string> LoginAsync(LogInModel model);
    }
}
