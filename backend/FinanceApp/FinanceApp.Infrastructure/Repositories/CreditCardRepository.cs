using Dapper;
using MySql.Data.MySqlClient;
using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;
using FinanceApp.Infrastructure.Data;

namespace FinanceApp.Infrastructure.Repositories
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public CreditCardRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Create(CreditCard card)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"INSERT INTO credit_cards
                        (id, name, credit_limit, closing_day, due_day, user_id, created_at)
                        VALUES
                        (@Id, @Name, @Limit, @ClosingDay, @DueDay, @UserId, @CreatedAt)";

            connection.Execute(sql, new
            {
                card.Id,
                card.Name,
                Limit = card.Limit,
                card.ClosingDay,
                card.DueDay,
                card.UserId,
                card.CreatedAt
            });
        }

        public CreditCard GetById(Guid id)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = "SELECT * FROM credit_cards WHERE id = @id";

            return connection.QueryFirstOrDefault<CreditCard>(sql, new { id });
        }

        public IEnumerable<CreditCard> GetByUser(Guid userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = "SELECT * FROM credit_cards WHERE user_id = @userId";

            return connection.Query<CreditCard>(sql, new { userId });
        }
    }
}