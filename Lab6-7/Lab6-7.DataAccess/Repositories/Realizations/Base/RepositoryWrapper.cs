using Lab6_7.DataAccess.Repositories.Interfaces.Base;
using Lab6_7.DataAccess.Repositories.Interfaces.Contractor;
using Lab6_7.DataAccess.Repositories.Interfaces.Product;
using Lab6_7.DataAccess.Repositories.Realizations.Contractor;
using Lab6_7.DataAccess.Repositories.Realizations.Product;
using System.Threading.Tasks;

namespace Lab6_7.DataAccess.Repositories.Realizations.Base
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private LabDbContext _dbContext;

        private IProductRepo _productRepo;
        private IContractorRepo _contractorRepo;

        public RepositoryWrapper(LabDbContext labDbContext)
        {
            _dbContext = labDbContext;
        }

        public IProductRepo ProductRepo
        {
            get
            {
                if (_productRepo == null)
                {
                    _productRepo = new ProductRepo(_dbContext);
                }

                return _productRepo;
            }
        }

        public IContractorRepo ContractorRepo
        {
            get
            {
                if (_contractorRepo == null)
                {
                    _contractorRepo = new ContractorRepo(_dbContext);
                }

                return _contractorRepo;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
