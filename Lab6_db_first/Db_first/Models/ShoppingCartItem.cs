using System;
using System.Collections.Generic;

#nullable disable

namespace Db_first.Models
{
    public partial class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }

        public virtual Product Product { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
