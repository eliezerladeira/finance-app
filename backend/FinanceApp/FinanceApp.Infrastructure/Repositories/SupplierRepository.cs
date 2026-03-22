using Dapper;
using FinanceApp.Application.DTOs;
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
    public class SupplierRepository : ISupplierRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public SupplierRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Create(Supplier supplier)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = "INSERT INTO suppliers (id, name) VALUES (@Id, @Name)";
            connection.Execute(sql, supplier);
        }

        public List<Supplier> GetAll()
        {
            using var connection = _connectionFactory.CreateConnection();

            return connection.Query<Supplier>("SELECT * FROM suppliers").ToList();
        }

        public List<Supplier> GetWithBalance()
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"
                SELECT 
                    s.id AS Id,
                    s.name AS Name,
                    COALESCE(SUM(p.amount), 0) AS Balance
                FROM suppliers s
                LEFT JOIN purchases p ON p.supplier_id = s.id
                GROUP BY s.id, s.name
                ORDER BY s.name
            ";

            return connection.Query<Supplier>(sql).ToList();
        }
    }
}