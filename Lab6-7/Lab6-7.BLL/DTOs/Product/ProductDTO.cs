using System;
using System.ComponentModel.DataAnnotations;

namespace Lab6_7.BLL.DTOs.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Start date is required"), DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required"), DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [MaxLength(30, ErrorMessage = "DemoVersionLink length can't exceed the 30-character limit")]
        public string DemoVersion { get; set; }

        [MaxLength(30, ErrorMessage = "MediaLink length can't exceed the 30-character limit")]
        public string Media { get; set; }

        [MaxLength(30, ErrorMessage = "DocumentationLink length can't exceed the 30-character limit")]
        public string Documentation { get; set; }

        [MaxLength(30, ErrorMessage = "RepositoryLink length can't exceed the 30-character limit")]
        public string Repository { get; set; }
    }
}
