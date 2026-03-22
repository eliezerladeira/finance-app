using Dapper;
using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;
using FinanceApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Infrastructure.Repositories
{
    public class PurchaseGroupRepository : IPurchaseGroupRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public PurchaseGroupRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Create(PurchaseGroup group)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"
               INSERT INTO purchase_groups
                (id, credit_card_id, description, total_amount, total_installments, purchase_date)
                VALUES
                (@Id, @CreditCardId, @Description, @TotalAmount, @TotalInstallments, @PurchaseDate)
            ";

            connection.Execute(sql, group);
        }
    }
}