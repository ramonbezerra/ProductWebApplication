using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Provider : BaseEntity
    {
        public string ProviderDescription { get; private set; }
        public string ProviderCNPJ { get; private set; }
    }
}
