﻿using Lab6_7.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6_7.WebApi.ViewModels
{
    public class ContractorViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public GenderType Gender { get; set; }

        public string Contacts { get; set; }

        public string TechSkills { get; set; }

        public string SoftSkills { get; set; }

        public string Experience { get; set; }

        public string Education { get; set; }

        public bool IsApproved { get; set; }
    }
}
