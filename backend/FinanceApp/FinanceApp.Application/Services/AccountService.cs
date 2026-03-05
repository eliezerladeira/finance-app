using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Enums;
using FinanceApp.Domain.Repositories;

namespace FinanceApp.Application.Services
{
    /*
     * O que faz?
     * Cria conta
     * Busca contas do usuário
     * Calcula saldo usando ITransactionRepository
    */

    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public AccountService(
            IAccountRepository accountRepository,
            ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<Guid> CreateAccountAsync(
            string name,
            AccountType type,
            decimal initialBalance,
            Guid userId)
        {
            var account = new Account(name, type, initialBalance, userId);

            await _accountRepository.AddAsync(account);

            return account.Id;
        }

        public async Task<IEnumerable<Account>> GetAccountsByUserAsync(Guid userId)
        {
            return await _accountRepository.GetByUserIdAsync(userId);
        }

        public async Task<decimal> GetBalanceAsync(Guid accountId)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);

            if (account == null)
                throw new Exception("Conta não encontrada.");

            var transactions =
                await _transactionRepository.GetByAccountIdAsync(accountId);

            return CalculateBalance(account, transactions);
        }

        private decimal CalculateBalance(Account account, IEnumerable<Transaction> transactions)
        {
            return transactions.Sum(t =>
                    t.Type == TransactionType.Income
                        ? t.Amount
                        : -t.Amount)
                    + account.InitialBalance;
        }
    }
}