using Dapper;
using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;
using FinanceApp.Infrastructure.Data;
using System.Data;

namespace FinanceApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public UserRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(User user)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();

            var sql = @"
                INSERT INTO users (Id, Name, Email, PasswordHash, CreatedAt, IsActive)
                VALUES (@Id, @Name, @Email, @PasswordHash, @CreatedAt, @IsActive)";

            await connection.ExecuteAsync(sql, new
            {
                user.Id,
                user.Name,
                Email = user.Email.Address,
                user.PasswordHash,
                user.CreatedAt,
                user.IsActive
            });
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();

            var sql = "SELECT * FROM users WHERE Id = @Id";

            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();

            var sql = "SELECT * FROM users WHERE Email = @Email";

            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Email = email });
        }
    }
}