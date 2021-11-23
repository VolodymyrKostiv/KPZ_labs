using Lab6_7.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_7.DataAccess.Models
{
    public class Contractor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
        public ICollection<string> Contacts { get; set; }
        public ICollection<string> TechSkills { get; set; }
        public ICollection<string> SoftSkills { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
    }
}
