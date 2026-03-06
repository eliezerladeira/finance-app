using Microsoft.AspNetCore.Mvc;
using FinanceApp.Application.Services;

namespace FinanceApp.Api.Controllers
{
    [ApiController]
    [Route("api/creditcards")]
    public class CreditCardsController : ControllerBase
    {
        private readonly CreditCardService _creditCardService;

        public CreditCardsController(CreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost]
        public IActionResult Create(
            string name,
            decimal limit,
            int closingDay,
            int dueDay,
            Guid userId)
        {
            var cardId = _creditCardService.CreateCard(
                name,
                limit,
                closingDay,
                dueDay,
                userId);

            return Ok(new { cardId });
        }
    }
}