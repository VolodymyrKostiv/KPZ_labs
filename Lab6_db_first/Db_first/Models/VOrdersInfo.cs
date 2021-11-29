using System;
using System.Collections.Generic;

#nullable disable

namespace Db_first.Models
{
    public partial class VOrdersInfo
    {
        public string Customer { get; set; }
        public string Type { get; set; }
        public DateTime Time { get; set; }
        public double ToPay { get; set; }
        public double Paid { get; set; }
    }
}
