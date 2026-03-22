using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;

namespace FinanceApp.Application.Services
{
    public class CreditCardService
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly IPurchaseRepository _purchaseRepository; // injeta PurchaseRepository no Service
        private readonly IInvoiceRepository _invoiceRepository;

        public CreditCardService(ICreditCardRepository creditCardRepository, IPurchaseRepository purchaseRepository, IInvoiceRepository invoiceRepository)
        {
            _creditCardRepository = creditCardRepository;
            _purchaseRepository = purchaseRepository;
            _invoiceRepository = invoiceRepository;
        }

        public Guid CreateCard(
            string name,
            decimal limit,
            int closingDay,
            int dueDay,
            Guid userId)
        {
            var card = new CreditCard(name, limit, closingDay, dueDay, userId);

            _creditCardRepository.Create(card);

            return card.Id;
        }

        public decimal GetAvailableLimit(Guid creditCardId)
        {
            // método para calular limite disponível
            var card = _creditCardRepository.GetById(creditCardId);

            if (card == null)
                throw new Exception("Cartão não encontrado");

            var totalPurchases = _purchaseRepository.GetTotalOpenPurchasesByCard(creditCardId);

            return card.Limit - totalPurchases;
        }

        public DateTime CalculateInvoiceMonth(DateTime purchaseDate, int closingDay)
        {
            // calcula a fatura da compra, retorna algo como 2026-03-01 que representa a fatura de março
            if (purchaseDate.Day <= closingDay)
            {
                return new DateTime(purchaseDate.Year, purchaseDate.Month, 1);
            }
            else
            {
                var nextMonth = purchaseDate.AddMonths(1);
                return new DateTime(nextMonth.Year, nextMonth.Month, 1);
            }
        }

        public Invoice GetOrCreateInvoice(Guid creditCardId, DateTime invoiceMonth)
        {
            // método que busca ou cria fatura
            var invoice = _invoiceRepository.GetByCardAndMonth(
                creditCardId,
                invoiceMonth.Month,
                invoiceMonth.Year
            );

            if (invoice != null)
                return invoice;

            var newInvoice = new Invoice(
                creditCardId,
                invoiceMonth.Month,
                invoiceMonth.Year
            );

            _invoiceRepository.Create(newInvoice);

            return newInvoice;
        }
    }
}