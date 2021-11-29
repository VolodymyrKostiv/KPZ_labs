using System;
using System.Collections.Generic;

#nullable disable

namespace Db_first.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductSpecifications = new HashSet<ProductSpecification>();
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductBrandId { get; set; }
        public int ProductSubcategoryId { get; set; }
        public int ProductUnitId { get; set; }
        public double Price { get; set; }

        public virtual ProductBrand ProductBrand { get; set; }
        public virtual ProductSubcategory ProductSubcategory { get; set; }
        public virtual ProductUnit ProductUnit { get; set; }
        public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
