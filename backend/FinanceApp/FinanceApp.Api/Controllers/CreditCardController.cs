using Microsoft.AspNetCore.Mvc;
using FinanceApp.Application.Services;

namespace FinanceApp.Api.Controllers
{
    [ApiController]
    [Route("api/creditcards")]
    public class CreditCardController : ControllerBase
    {
        private readonly CreditCardService _creditCardService;

        public CreditCardController(CreditCardService creditCardService)
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

        // endpoint para consultar limite
        [HttpGet("{id}/available-limit")]
        public IActionResult GetAvailableLimit(Guid id)
        {
            var limit = _creditCardService.GetAvailableLimit(id);

            return Ok(new
            {
                creditCardId = id,
                availableLimit = limit
            });
        }
    }
}