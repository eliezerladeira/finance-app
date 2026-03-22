using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Domain.Entities
{
    public class PurchaseGroup
    {
        public Guid Id { get; private set; }

        public Guid CreditCardId { get; private set; }

        public string Description { get; private set; }

        public decimal TotalAmount { get; private set; }

        public int TotalInstallments { get; private set; }

        public DateTime PurchaseDate { get; private set; }

        private PurchaseGroup() { }

        public PurchaseGroup(
            Guid creditCardId,
            string description,
            decimal totalAmount,
            int totalInstallments,
            DateTime purchaseDate)
        {
            Id = Guid.NewGuid();
            CreditCardId = creditCardId;
            Description = description;
            TotalAmount = totalAmount;
            TotalInstallments = totalInstallments;
            PurchaseDate = purchaseDate;
        }
    }
}