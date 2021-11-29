using System;
using System.Collections.Generic;

#nullable disable

namespace Db_first.Models
{
    public partial class ProductSpecification
    {
        public int ProductId { get; set; }
        public int SpecificationId { get; set; }
        public string Value { get; set; }

        public virtual Product Product { get; set; }
        public virtual Specification Specification { get; set; }
    }
}
