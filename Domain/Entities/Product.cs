using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductStatus Status { get; set; } = ProductStatus.Active;
        public DateTime FabricationDate { get; set; }
        public DateTime LimitDate { get; set; }
        public string ProviderDescription { get; set; }
        public string ProviderCnpj { get; set; }
    }
}
