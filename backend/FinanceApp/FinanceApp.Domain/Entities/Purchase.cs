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
        public int InstallmentNumber { get; private set; }
        public int TotalInstallments { get; private set; }
        public Guid? PurchaseGroupId { get; private set; }
        public Guid? SupplierId { get; private set; }

        private Purchase() { }

        public Purchase(
            Guid creditCardId,
            Guid invoiceId,
            string description,
            decimal amount,
            DateTime purchaseDate,
            int installmentNumber,
            int totalInstallments,
            Guid? PurchaseGroupId)
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
            InstallmentNumber = installmentNumber;
            TotalInstallments = totalInstallments;
            PurchaseGroupId = PurchaseGroupId;
        }

        // compra simples
        public static Purchase CreateSingle(
            Guid creditCardId,
            Guid invoiceId,
            string description,
            decimal amount,
            DateTime purchaseDate)
        {
            return new Purchase(
                creditCardId,
                invoiceId,
                description,
                amount,
                purchaseDate,
                1,
                1,
                null);
        }

        // compra parcelada
        public static Purchase CreateInstallment(
            Guid creditCardId,
            Guid invoiceId,
            string description,
            decimal amount,
            DateTime purchaseDate,
            int installmentNumber,
            int totalInstallments,
            Guid? parentPurchaseId)
        {
            return new Purchase(
                creditCardId,
                invoiceId,
                description,
                amount,
                purchaseDate,
                installmentNumber,
                totalInstallments,
                parentPurchaseId);
        }
    }
}