using System;
using System.Collections.Generic;

#nullable disable

namespace Db_first.Models
{
    public partial class VProductInfo
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Subcategory { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
    }
}
