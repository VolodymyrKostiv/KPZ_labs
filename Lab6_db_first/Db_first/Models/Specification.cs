using System;
using System.Collections.Generic;

#nullable disable

namespace Db_first.Models
{
    public partial class Specification
    {
        public Specification()
        {
            ProductSpecifications = new HashSet<ProductSpecification>();
        }

        public int SpecificationId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; }
    }
}
