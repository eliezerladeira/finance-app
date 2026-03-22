using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Domain.Entities
{
    public class Supplier
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private Supplier() { }

        public Supplier(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}