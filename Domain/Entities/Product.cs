﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ProductStatus ProductStatus { get; private set; }
        public DateTime FabricationDate { get; private set; }
        public DateTime LimitDate { get; private set; }
        public virtual Provider Provider { get; private set; }
    }
}
