using System;
using System.Collections.Generic;

#nullable disable

namespace Db_first.Models
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public int ShoppingCartId { get; set; }
        public int? CustomerId { get; set; }
        public double ToPay { get; set; }
        public double Paid { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
