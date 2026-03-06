using FinanceApp.Domain.Entities;

namespace FinanceApp.Domain.Repositories
{
    public interface IPurchaseRepository
    {
        void Create(Purchase purchase);
        IEnumerable<Purchase> GetByInvoice(Guid invoiceId);
    }
}