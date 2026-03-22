using Dapper;
using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;
using FinanceApp.Infrastructure.Data;

namespace FinanceApp.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public InvoiceRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Invoice GetByCardAndMonth(Guid cardId, int month, int year)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"SELECT * FROM invoices
                        WHERE credit_card_id = @cardId
                        AND month = @month
                        AND year = @year";

            return connection.QueryFirstOrDefault<Invoice>(sql, new
            {
                cardId,
                month,
                year
            });
        }

        public void Create(Invoice invoice)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"INSERT INTO invoices
                        (id, credit_card_id, month, year, total_amount, is_paid)
                        VALUES
                        (@Id, @CreditCardId, @Month, @Year, @TotalAmount, @IsPaid)";

            connection.Execute(sql, invoice);
        }

        public void Update(Invoice invoice)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"
                UPDATE invoices
                SET 
                total_amount = @TotalAmount,
                is_paid = @IsPaid
                WHERE id = @Id
            ";

            connection.Execute(sql, invoice);
        }
    }
}