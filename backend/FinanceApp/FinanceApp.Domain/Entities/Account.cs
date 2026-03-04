using System;
using FinanceApp.Domain.Enums;

namespace FinanceApp.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public AccountType Type { get; private set; }
        public decimal InitialBalance { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsActive { get; private set; }

        public Account(string name, AccountType type, decimal initialBalance, Guid userId)
        {
            Validate(name, userId);

            Id = Guid.NewGuid();
            Name = name;
            Type = type;
            InitialBalance = initialBalance;
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        private void Validate(string name, Guid userId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome da conta não pode ser vazio.");

            if (userId == Guid.Empty)
                throw new ArgumentException("UserId é obrigatório.");
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Nome da conta não pode ser vazio.");

            Name = newName;
        }
    }
}