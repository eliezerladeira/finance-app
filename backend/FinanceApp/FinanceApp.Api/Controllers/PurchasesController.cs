using Microsoft.AspNetCore.Mvc;
using FinanceApp.Application.Services;

namespace FinanceApp.Api.Controllers
{
    [ApiController]
    [Route("api/purchases")]
    public class PurchasesController : ControllerBase
    {
        private readonly PurchaseService _purchaseService;

        public PurchasesController(PurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        public IActionResult Create(
            Guid creditCardId,
            Guid invoiceId,
            string description,
            decimal amount)
        {
            var purchaseId = _purchaseService.CreatePurchase(
                creditCardId,
                invoiceId,
                description,
                amount,
                DateTime.UtcNow);

            return Ok(new { purchaseId });
        }
    }
}