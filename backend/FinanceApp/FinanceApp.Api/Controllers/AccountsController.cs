using Microsoft.AspNetCore.Mvc;
using FinanceApp.Application.Services;
using FinanceApp.Domain.Enums;

namespace FinanceApp.Api.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountsController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult Create(
            string name,
            AccountType type,
            decimal initialBalance,
            Guid userId)
        {
            var accountId = _accountService.CreateAccountAsync(name, type, initialBalance, userId);

            return Ok(new { accountId });
        }
    }
}