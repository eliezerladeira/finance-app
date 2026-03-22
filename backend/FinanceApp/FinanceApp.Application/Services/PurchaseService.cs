using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;
using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Application.Services
{
    public class PurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly ICreditCardRepository _cardRepository;
        private readonly InvoiceService _invoiceService;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly CreditCardService _creditCardService;
        private readonly IPurchaseGroupRepository _purchaseGroupRepository;

        public PurchaseService(
            IPurchaseRepository purchaseRepository,
            ICreditCardRepository cardRepository,
            IInvoiceRepository invoiceRepository,
            CreditCardService creditCardService,
            InvoiceService invoiceService,
            IPurchaseGroupRepository purchaseGroupRepository)
        {
            _purchaseRepository = purchaseRepository;
            _cardRepository = cardRepository;
            _invoiceRepository = invoiceRepository;
            _creditCardService = creditCardService;
            _invoiceService = invoiceService;
            _purchaseGroupRepository = purchaseGroupRepository;
        }

        public Guid CreatePurchase(
            Guid creditCardId,
            string description,
            decimal amount,
            DateTime purchaseDate)
        {
            // busca cartão; busca ou cria a fatura; cria a compra; salva no banco;
            // Valida o cartão; Valida o limite; atualiza total da fatura
            var card = _cardRepository.GetById(creditCardId);

            if (card == null)
                throw new Exception("Cartão não encontrado");

            // verificar limite disponível
            var availableLimit = _creditCardService.GetAvailableLimit(creditCardId);

            if (amount > availableLimit)
                throw new Exception("Limite do cartão insuficiente");

            // buscar ou criar fatura correta
            var invoice = _invoiceService
                .GetOrCreateInvoice(card, purchaseDate);

            // criar compra
            var purchase = new Purchase(
                creditCardId,
                invoice.Id,
                description,
                amount,
                purchaseDate,
                1,
                1,
                null);

            _purchaseRepository.Create(purchase);

            // atualizar total da fatura
            invoice.AddPurchase(amount);

            _invoiceRepository.Update(invoice);

            return purchase.Id;
        }

        public void CreateInstallmentPurchase(
            Guid creditCardId,
            string description,
            decimal totalAmount,
            int installments,
            DateTime purchaseDate)
        {
            var card = _cardRepository.GetById(creditCardId);

            if (card == null)
                throw new Exception("Cartão não encontrado!");

            var availableLimit = _creditCardService.GetAvailableLimit(creditCardId);

            if (totalAmount > availableLimit)
                throw new Exception("Limite do cartão insuficiente!");

            if (installments <= 0)
                throw new Exception("Número de parcelas inválido!");

            // cria o grupo
            var group = new PurchaseGroup(
                creditCardId,
                description,
                totalAmount,
                installments,
                purchaseDate
            );

            _purchaseGroupRepository.Create(group);

            //var installmentValue = Math.Round(totalAmount / installments, 2);
            var installmentValue = Math.Floor((totalAmount / installments) * 100) / 100;

            decimal accumulated = 0;

            //Guid? parentPurchaseId = null;

            for (int i = 0; i < installments; i++)
            {
                decimal value;

                if (i < installments - 1)
                {
                    value = installmentValue;
                    accumulated += value;
                }
                else
                {
                    value = totalAmount - accumulated;
                }

                var date = purchaseDate.AddMonths(i);

                var invoice = _invoiceService
                    .GetOrCreateInvoice(card, date);

                var purchase = new Purchase(
                    creditCardId,
                    invoice.Id,
                    $"{description} ({i + 1}/{installments})",
                    value,
                    date,
                    i + 1,
                    installments,
                    group.Id
                );

                _purchaseRepository.Create(purchase);
                invoice.AddPurchase(value);
                _invoiceRepository.Update(invoice);
            }
        }
    }
}