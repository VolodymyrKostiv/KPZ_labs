using System;
using System.Collections.Generic;

#nullable disable

namespace Db_first.Models
{
    public partial class Customer
    {
        public Customer()
        {
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int CustomerId { get; set; }
        public int CustomerTypeId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual CustomerType CustomerType { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
