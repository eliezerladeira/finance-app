using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceApp.Domain.Enums;

namespace FinanceApp.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; private set; }
        public Guid AccountId { get; private set; }
        public decimal Amount { get; private set; }
        public TransactionType Type { get; private set; }
        public string? Description { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Transaction(Guid accountId, decimal amount, TransactionType type, DateTime date, string? description = null)
        {
            Validate(accountId, amount);

            Id = Guid.NewGuid();
            AccountId = accountId;
            Amount = amount;
            Type = type;
            Date = date;
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }

        private void Validate(Guid accountId, decimal amount)
        {
            if (accountId == Guid.Empty)
                throw new ArgumentException("AccountId é obrigatório.");

            if (amount <= 0)
                throw new ArgumentException("Valor da transação deve ser maior que zero.");
        }
    }
}