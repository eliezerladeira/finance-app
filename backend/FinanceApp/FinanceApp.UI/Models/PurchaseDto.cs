using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.UI.Models
{
    public class PurchaseDto
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int InstallmentNumber { get; set; }
        public int TotalInstallments { get; set; }
        public Guid? PurchaseGroupId { get; set; }
    }
}