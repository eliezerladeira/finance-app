using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Enums;

namespace FinanceApp.Application.Services
{
    public class AccountService
    {
        public decimal CalculateBalance(Account account, IEnumerable<Transaction> transactions)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            if (transactions == null)
                throw new ArgumentNullException(nameof(transactions));

            var balance = transactions
                .Where(t => t.AccountId == account.Id)
                .Sum(t => t.Type == TransactionType.Income
                            ? t.Amount
                            : -t.Amount);

            return balance;
        }
    }
}