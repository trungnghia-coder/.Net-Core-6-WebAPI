using Microsoft.AspNetCore.Mvc;
using MyAPINetCore.Repositories;

namespace MyAPINetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] MyAPINetCore.Models.RegisterModel model)
        {
            var result = await accountRepository.RegisterAsync(model);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok("User registered successfully");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] MyAPINetCore.Models.LogInModel model)
        {
            var token = await accountRepository.LoginAsync(model);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { Token = token });
        }

    }
}
