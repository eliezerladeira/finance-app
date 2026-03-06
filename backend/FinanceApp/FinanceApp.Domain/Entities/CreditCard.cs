using System;

namespace FinanceApp.Domain.Entities
{
    public class CreditCard
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Limit { get; private set; }
        public int ClosingDay { get; private set; }
        public int DueDay { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public CreditCard(string name, decimal limit, int closingDay, int dueDay, Guid userId)
        {
            Validate(name, limit, closingDay, dueDay, userId);

            Id = Guid.NewGuid();
            Name = name;
            Limit = limit;
            ClosingDay = closingDay;
            DueDay = dueDay;
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
        }

        private void Validate(string name, decimal limit, int closingDay, int dueDay, Guid userId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome do cartão inválido.");

            if (limit <= 0)
                throw new ArgumentException("Limite inválido.");

            if (closingDay < 1 || closingDay > 31)
                throw new ArgumentException("Dia de fechamento inválido.");

            if (dueDay < 1 || dueDay > 31)
                throw new ArgumentException("Dia de vencimento inválido.");

            if (userId == Guid.Empty)
                throw new ArgumentException("Usuário inválido.");
        }
    }
}