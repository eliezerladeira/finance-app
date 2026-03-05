using Dapper;
using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;
using FinanceApp.Infrastructure.Data;
using System.Data;

namespace FinanceApp.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public AccountRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Account account)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();

            var sql = @"
                INSERT INTO accounts
                (Id, Name, Type, InitialBalance, UserId, CreatedAt, IsActive)
                VALUES
                (@Id, @Name, @Type, @InitialBalance, @UserId, @CreatedAt, @IsActive)";

            await connection.ExecuteAsync(sql, account);
        }

        public async Task<Account?> GetByIdAsync(Guid id)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();

            var sql = "SELECT * FROM accounts WHERE Id = @Id";

            return await connection.QueryFirstOrDefaultAsync<Account>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Account>> GetByUserIdAsync(Guid userId)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();

            var sql = "SELECT * FROM accounts WHERE UserId = @UserId";

            return await connection.QueryAsync<Account>(sql, new { UserId = userId });
        }
    }
}