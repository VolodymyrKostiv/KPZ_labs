using System;

namespace Lab6_7.WebApi.ViewModels
{
    public class ProductViewModel
    {
        public int Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string DemoVersion { get; set; }

        public string Media { get; set; }

        public string Documentation { get; set; }

        public string Repository { get; set; }
    }
}
