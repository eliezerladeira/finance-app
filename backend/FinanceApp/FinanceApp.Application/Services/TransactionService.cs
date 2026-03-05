using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Enums;
using FinanceApp.Domain.Repositories;

namespace FinanceApp.Application.Services
{
    /*
     * É responsável por:
     * Registrar entrada
     * Registrar saída
     * Garantir que a conta exista
     * Ele deve:
     * ✔ Criar transação
     * ✔ Validar conta existente
     * ✔ Garantir valor positivo
     * ✔ Salvar via repositório
     * 
     * ✔ Application verifica existência da conta
     * ✔ Domain valida valor internamente também
     * ✔ Nenhuma dependência de banco
     * ✔ Fluxo pronto para UI
    */

    public class TransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public TransactionService(
            ITransactionRepository transactionRepository,
            IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        public async Task<Guid> AddTransactionAsync(
            Guid accountId,
            decimal amount,
            TransactionType type,
            DateTime date,
            string? description = null)
        {
            if (amount <= 0)
                throw new ArgumentException("O valor deve ser maior que zero.");

            var account = await _accountRepository.GetByIdAsync(accountId);

            if (account == null)
                throw new Exception("Conta não encontrada.");

            var transaction = new Transaction(
                accountId,
                amount,
                type,
                date,
                description);

            await _transactionRepository.AddAsync(transaction);

            return transaction.Id;
        }
    }
}