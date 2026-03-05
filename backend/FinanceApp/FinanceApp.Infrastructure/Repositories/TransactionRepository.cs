using Dapper;
using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;
using FinanceApp.Infrastructure.Data;
using System.Data;

namespace FinanceApp.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public TransactionRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Transaction transaction)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();

            var sql = @"
                INSERT INTO transactions
                (Id, AccountId, Amount, Type, Date, Description)
                VALUES
                (@Id, @AccountId, @Amount, @Type, @Date, @Description)";

            await connection.ExecuteAsync(sql, transaction);
        }

        public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(Guid accountId)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();

            var sql = "SELECT * FROM transactions WHERE AccountId = @AccountId";

            return await connection.QueryAsync<Transaction>(sql, new { AccountId = accountId });
        }
    }
}