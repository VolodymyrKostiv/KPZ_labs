﻿using Lab6_7.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_7.DataAccess.Repositories.Interfaces
{
    public interface IContractorRepo
    {
        IEnumerable<Contractor> GetAllContractors();
        Contractor GetContractorById(int id);
    }
}