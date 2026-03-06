using FinanceApp.Domain.Entities;

namespace FinanceApp.Domain.Repositories
{
    public interface ICreditCardRepository
    {
        void Create(CreditCard card);
        CreditCard GetById(Guid id);
        IEnumerable<CreditCard> GetByUser(Guid userId);
    }
}