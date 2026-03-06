using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;

namespace FinanceApp.Application.Services
{
    public class PurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public Guid CreatePurchase(
            Guid creditCardId,
            Guid invoiceId,
            string description,
            decimal amount,
            DateTime date)
        {
            var purchase = new Purchase(
                creditCardId,
                invoiceId,
                description,
                amount,
                date);

            _purchaseRepository.Create(purchase);

            return purchase.Id;
        }
    }
}