using System.ComponentModel.DataAnnotations;

namespace Lab6_7.BLL.DTOs.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "DemoVersionLink is required"), MaxLength(30, ErrorMessage = "DemoVersionLink length can't exceed the 30-character limit")]
        public string DemoVersion { get; set; }

        [Required(ErrorMessage = "MediaLink is required"), MaxLength(30, ErrorMessage = "MediaLink length can't exceed the 30-character limit")]
        public string Media { get; set; }

        [Required(ErrorMessage = "DocumentationLink is required"), MaxLength(30, ErrorMessage = "DocumentationLink length can't exceed the 30-character limit")]
        public string Documentation { get; set; }

        [Required(ErrorMessage = "RepositoryLink is required"), MaxLength(30, ErrorMessage = "RepositoryLink length can't exceed the 30-character limit")]
        public string Repository { get; set; }
    }
}
