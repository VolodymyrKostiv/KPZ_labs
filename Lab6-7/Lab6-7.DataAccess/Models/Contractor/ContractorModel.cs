using Lab6_7.DataAccess.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lab6_7.DataAccess.Models.Contractor
{
    public class ContractorModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required"), MaxLength(50, ErrorMessage = "FirstName length can't exceed the 50-character limit")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required"), MaxLength(50, ErrorMessage = "LastName length can't exceed the 50-character limit")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "UserName is required"), MaxLength(50, ErrorMessage = "UserName length can't exceed the 50-character limit")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required"), MaxLength(30, ErrorMessage = "Password length can't exceed the 30-character limit")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Email address isn't valid")]
        public string Email { get; set; }

        [Range(18, 99, ErrorMessage = "Age must be between 18 and 99")]
        public int Age { get; set; }

        [EnumDataType(typeof(GenderType), ErrorMessage ="Gender must be valid (only three types)")]
        public GenderType Gender { get; set; }

        [MaxLength(200, ErrorMessage = "Password length can't exceed the 200-character limit")]
        public string Contacts { get; set; }

        [MaxLength(200, ErrorMessage = "TechSkills length can't exceed the 200-character limit")]
        public string TechSkills { get; set; }

        [MaxLength(200, ErrorMessage = "SoftSkills length can't exceed the 200-character limit")]
        public string SoftSkills { get; set; }

        [MaxLength(300, ErrorMessage = "Experience length can't exceed the 200-character limit")]
        public string Experience { get; set; }

        [MaxLength(300, ErrorMessage = "Education length can't exceed the 200-character limit")]
        public string Education { get; set; }
    }
}
