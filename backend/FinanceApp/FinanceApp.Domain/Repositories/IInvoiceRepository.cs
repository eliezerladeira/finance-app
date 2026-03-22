using FinanceApp.Domain.Entities;

namespace FinanceApp.Domain.Repositories
{
    public interface IInvoiceRepository
    {
        Invoice GetByCardAndMonth(Guid cardId, int month, int year);
        void Create(Invoice invoice);
        void Update(Invoice invoice);
    }
}