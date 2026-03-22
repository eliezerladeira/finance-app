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
            string description,
            decimal amount)
        {
            var purchaseId = _purchaseService.CreatePurchase(
                creditCardId,
                description,
                amount,
                DateTime.UtcNow);

            return Ok(new { purchaseId });
        }

        [HttpPost("installments")]
        public IActionResult CreateInstallments(
            Guid creditCardId,
            string description,
            decimal totalAmount,
            int installments)
        {
            _purchaseService.CreateInstallmentPurchase(
                creditCardId,
                description,
                totalAmount,
                installments,
                DateTime.UtcNow);

            return Ok("Compra parcelada registrada.");
        }
    }
}