using Microsoft.AspNetCore.Mvc;
using FinanceApp.Application.Services;

namespace FinanceApp.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(
            string name,
            string email,
            string password)
        {
            var userId = await _userService.CreateUserAsync(name, email, password);

            return Ok(new { userId });
        }
    }
}