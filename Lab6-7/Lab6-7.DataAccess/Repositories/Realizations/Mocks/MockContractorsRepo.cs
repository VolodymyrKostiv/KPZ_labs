using Lab6_7.DataAccess.Models;
using Lab6_7.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_7.DataAccess.Repositories.Realizations.Mocks
{
    public class MockContractorsRepo : IContractorRepo
    {
        public IEnumerable<Contractor> GetAllContractors()
        {
            return new List<Contractor>() 
            { 
                new Contractor() { Id = 0, FirstName = "Man - 1", Age = 20 },
                new Contractor() { Id = 1, FirstName = "Man - 2", Age = 30 },
            };
        }

        public Contractor GetContractorById(int id)
        {
            return new Contractor() { Id = 0, FirstName = "Solo Man", Age = 20 };
        }
    }
}
