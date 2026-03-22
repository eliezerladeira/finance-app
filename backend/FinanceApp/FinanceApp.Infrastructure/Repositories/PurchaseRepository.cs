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

        public decimal GetTotalOpenPurchasesByCard(Guid creditCardId)
        {
            // método retorna total de compras ainda não pagas
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"
                SELECT COALESCE(SUM(p.amount),0)
                FROM purchases p
                JOIN invoices i ON p.invoice_id = i.id
                WHERE i.credit_card_id = @creditCardId
                AND i.is_paid = 0
            ";

            return connection.ExecuteScalar<decimal>(sql, new { creditCardId });
        }
    }
}