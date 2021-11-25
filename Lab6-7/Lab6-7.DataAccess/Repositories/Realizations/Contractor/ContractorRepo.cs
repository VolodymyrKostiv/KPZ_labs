using Lab6_7.DataAccess.Models.Contractor;
using Lab6_7.DataAccess.Repositories.Interfaces.Contractor;
using Lab6_7.DataAccess.Repositories.Realizations.Base;

namespace Lab6_7.DataAccess.Repositories.Realizations.Contractor
{
    public class ContractorRepo : RepositoryBase<ContractorModel>, IContractorRepo
    {
        public ContractorRepo(LabDbContext context) 
            : base(context)
        {
        }
    }
}
