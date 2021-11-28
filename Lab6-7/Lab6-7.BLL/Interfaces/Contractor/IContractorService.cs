using Lab6_7.BLL.DTOs.Contractor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab6_7.BLL.Interfaces.Contractor
{
    /// <summary>
    /// Defines operations to work with contractor
    /// </summary>
    public interface IContractorService
    {
        /// <summary>
        /// Asynchronously get all of the contractors
        /// </summary>
        /// <returns>List of contractors</returns>
        Task<IEnumerable<ContractorDTO>> GetAllContractorsAsync();

        /// <summary>
        /// Asynchronously get the contractor by his Id
        /// </summary>
        /// <param name="id">The id of contractor we need to get</param>
        /// <returns>Found contractor</returns>
        Task<ContractorDTO> GetContractorAsync(int id);

        /// <summary>
        /// Asynchronously add new contractor
        /// </summary>
        /// <param name="contractorDTO">The data of new contractor</param>
        /// <returns>Nothing</returns>
        Task AddContractorAsync(ContractorDTO contractorDTO);

        /// <summary>
        /// Asynchronously change the data of specified contractor
        /// </summary>
        /// <param name="contractorDTO">The new data for contractor</param>
        /// <returns>Nothing</returns>
        Task ChangeContractorAsync(int id, ContractorDTO contractorDTO);


        /// <summary>
        /// Asynchronously delete chosen contractor
        /// </summary>
        /// <param name="contractorDTO">The contractor we need to delete</param>
        /// <returns>Nothing</returns>
        Task DeleteContractorAsync(ContractorDTO contractorDTO);

        /// <summary>
        /// Asynchronously delete chosen contractor
        /// </summary>
        /// <param name="id">The id of contractor we need to delete</param>
        /// <returns>Nothing</returns>
        Task DeleteContractorAsync(int id);
    }
}
