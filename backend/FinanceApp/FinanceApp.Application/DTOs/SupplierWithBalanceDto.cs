using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Application.DTOs
{
    public class SupplierWithBalanceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}