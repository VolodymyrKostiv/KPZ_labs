using Lab6_7.BLL.DTOs.Contractor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab6_7.BLL.Interfaces.Contractor
{
    public interface IContractorService
    {
        Task<IEnumerable<ContractorDTO>> GetAllContractorsAsync();

        Task<ContractorDTO> GetContractorAsync(int id);

        Task AddContractorAsync(ContractorDTO contractorDTO);

        Task ChangeContractorAsync(ContractorDTO contractorDTO);

        Task DeleteContractorAsync(ContractorDTO contractorDTO);

        Task DeleteContractorAsync(int id);
    }
}
