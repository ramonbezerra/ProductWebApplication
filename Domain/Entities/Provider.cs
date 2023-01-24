using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Provider : BaseEntity
    {
        public string Description { get; private set; }
        public string Cnpj { get; private set; }
        public int ProductId { get; private set; }
        public virtual Product Product { get; private set; }
    }
}
