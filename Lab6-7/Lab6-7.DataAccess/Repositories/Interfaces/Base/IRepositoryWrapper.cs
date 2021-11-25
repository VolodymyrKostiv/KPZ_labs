using Lab6_7.DataAccess.Repositories.Interfaces.Contractor;
using Lab6_7.DataAccess.Repositories.Interfaces.Product;
using System.Threading.Tasks;

namespace Lab6_7.DataAccess.Repositories.Interfaces.Base
{
    public interface IRepositoryWrapper
    {
        IContractorRepo ContractorRepo { get; }

        IProductRepo ProductRepo { get; }

        void Save();

        Task SaveAsync();
    }
}
