using FinanceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Domain.Repositories
{
    public interface IPurchaseGroupRepository
    {
        void Create(PurchaseGroup group);
    }
}