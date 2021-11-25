using Lab6_7.DataAccess.Models.Contractor;
using System.Collections.Generic;

namespace Lab6_7.DataAccess.Repositories.Realizations.Mocks
{
    public class MockContractorsRepo // : IContractorRepo
    {
        public IEnumerable<ContractorModel> GetAllContractors()
        {
            return new List<ContractorModel>() 
            { 
                new ContractorModel() { Id = 0, FirstName = "Man - 1", Age = 20 },
                new ContractorModel() { Id = 1, FirstName = "Man - 2", Age = 30 },
            };
        }

        public ContractorModel GetContractorById(int id)
        {
            return new ContractorModel() { Id = 0, FirstName = "Solo Man", Age = 20 };
        }
    }
}
