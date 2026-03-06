using Dapper;
using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;
using FinanceApp.Infrastructure.Data;

namespace FinanceApp.Infrastructure.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public PurchaseRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Create(Purchase purchase)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"INSERT INTO purchases
                        (id, credit_card_id, invoice_id, description, amount, purchase_date)
                        VALUES
                        (@Id, @CreditCardId, @InvoiceId, @Description, @Amount, @PurchaseDate)";

            connection.Execute(sql, purchase);
        }

        public IEnumerable<Purchase> GetByInvoice(Guid invoiceId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = "SELECT * FROM purchases WHERE invoice_id = @invoiceId";

            return connection.Query<Purchase>(sql, new { invoiceId });
        }
    }
}