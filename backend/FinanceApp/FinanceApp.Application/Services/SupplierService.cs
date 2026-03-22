using FinanceApp.Application.DTOs;
using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Application.Services
{
    public class SupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public void Create(string name)
        {
            var supplier = new Supplier(name);
            _repository.Create(supplier);
        }

        public List<Supplier> GetAll()
        {
            return _repository.GetAll();
        }

        public List<SupplierWithBalanceDto> GetWithBalance()
        {
            var suppliers = _repository.GetWithBalance();

            return suppliers.Select(s => new SupplierWithBalanceDto
            {
                Id = s.Id,
                Name = s.Name,
                Balance = s.Balance
            }).ToList();
        }
    }
}