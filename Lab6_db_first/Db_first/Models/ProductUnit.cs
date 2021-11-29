using System;
using System.Collections.Generic;

#nullable disable

namespace Db_first.Models
{
    public partial class ProductUnit
    {
        public ProductUnit()
        {
            Products = new HashSet<Product>();
        }

        public int ProductUnitId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
