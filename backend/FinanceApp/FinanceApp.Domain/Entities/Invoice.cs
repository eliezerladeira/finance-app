using System;

namespace FinanceApp.Domain.Entities
{
    public class Invoice
    {
        public Guid Id { get; private set; }
        public Guid CreditCardId { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }
        public decimal TotalAmount { get; private set; }
        public bool IsPaid { get; private set; }

        public Invoice(Guid creditCardId, int month, int year)
        {
            Id = Guid.NewGuid();
            CreditCardId = creditCardId;
            Month = month;
            Year = year;
            TotalAmount = 0;
            IsPaid = false;
        }

        public void AddPurchase(decimal amount)
        {
            TotalAmount += amount;
        }

        public void MarkAsPaid()
        {
            IsPaid = true;
        }
    }
}