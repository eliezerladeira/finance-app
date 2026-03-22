using FinanceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Domain.Repositories
{
    public interface ISupplierRepository
    {
        void Create(Supplier supplier);
        List<Supplier> GetAll();
        List<Supplier> GetWithBalance();
    }
}