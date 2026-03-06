using System;

namespace FinanceApp.Domain.Entities
{
    public class Purchase
    {
        public Guid Id { get; private set; }
        public Guid CreditCardId { get; private set; }
        public Guid InvoiceId { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime PurchaseDate { get; private set; }

        public Purchase(
            Guid creditCardId,
            Guid invoiceId,
            string description,
            decimal amount,
            DateTime purchaseDate)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Descrição inválida.");

            if (amount <= 0)
                throw new ArgumentException("Valor inválido.");

            Id = Guid.NewGuid();
            CreditCardId = creditCardId;
            InvoiceId = invoiceId;
            Description = description;
            Amount = amount;
            PurchaseDate = purchaseDate;
        }
    }
}