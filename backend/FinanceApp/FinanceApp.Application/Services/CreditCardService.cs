using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;

namespace FinanceApp.Application.Services
{
    public class CreditCardService
    {
        private readonly ICreditCardRepository _creditCardRepository;

        public CreditCardService(ICreditCardRepository creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
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
    }
}