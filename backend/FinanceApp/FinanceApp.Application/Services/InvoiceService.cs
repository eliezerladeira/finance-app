using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;

namespace FinanceApp.Application.Services
{
    public class InvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public Invoice GetOrCreateInvoice(
            CreditCard card,
            DateTime purchaseDate)
        {
            var month = purchaseDate.Month;
            var year = purchaseDate.Year;

            if (purchaseDate.Day > card.ClosingDay)
            {
                var next = purchaseDate.AddMonths(1);
                month = next.Month;
                year = next.Year;
            }

            var invoice = _invoiceRepository
                .GetByCardAndMonth(card.Id, month, year);

            if (invoice != null)
                return invoice;

            invoice = new Invoice(card.Id, month, year);

            _invoiceRepository.Create(invoice);

            return invoice;
        }
    }
}