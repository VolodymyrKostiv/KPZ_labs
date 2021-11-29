using System;
using System.Collections.Generic;

#nullable disable

namespace Db_first.Models
{
    public partial class CustomerType
    {
        public CustomerType()
        {
            Customers = new HashSet<Customer>();
        }

        public int CustomerTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
