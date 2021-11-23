using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_7.DataAccess.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string DemoVersion { get; set; }
        public string Media { get; set; }
        public string Documentation { get; set; }
        public string Repository { get; set; }
    }
}
