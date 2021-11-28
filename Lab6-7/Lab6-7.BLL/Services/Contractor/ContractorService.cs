using AutoMapper;
using Lab6_7.BLL.DTOs.Contractor;
using Lab6_7.BLL.Interfaces.Contractor;
using Lab6_7.DataAccess.Models.Contractor;
using Lab6_7.DataAccess.Repositories.Interfaces.Contractor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab6_7.BLL.Services.Contractor
{
    /// <summary>
    /// Implements operations to work with contractor
    /// </summary>
    public class ContractorService : IContractorService
    {
        private readonly IContractorRepo _contractorRepo;
        private readonly IMapper _mapper;

        public ContractorService(
            IContractorRepo contractorRepo, 
            IMapper mapper)
        {
            _contractorRepo = contractorRepo;
            _mapper = mapper;
        }


        /// <inheritdoc/>
        public async Task AddContractorAsync(ContractorDTO contractorDTO)
        {
            var contractor = _mapper.Map<ContractorDTO, ContractorModel>(contractorDTO);

            if(contractor == null)
            {
                throw new ArgumentException("Exception just for fun");
            }

            await _contractorRepo.CreateAsync(contractor);

            await _contractorRepo.SaveAsync();
        }

        /// <inheritdoc/>
        public async Task ChangeContractorAsync(int id, ContractorDTO contractorDTO)
        {
            var contractor = await _contractorRepo.GetFirstOrDefaultAsync(c => c.Id == id);

            if (contractor == null)
            {
                throw new ArgumentNullException("Contractor doesnt exist");
            }

            contractorDTO.Id = id;

            _contractorRepo.Update(contractor);

            await _contractorRepo.SaveAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteContractorAsync(ContractorDTO contractorDTO)
        {
            var contractor = await _contractorRepo.GetFirstOrDefaultAsync(c => c.Id == contractorDTO.Id);

            if (contractor == null)
            {
                throw new ArgumentNullException("Contractor doesnt exist");
            }

            _contractorRepo.Delete(contractor);

            await _contractorRepo.SaveAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteContractorAsync(int id)
        {
            var contractor = await _contractorRepo.GetFirstOrDefaultAsync(c => c.Id == id);

            if (contractor == null)
            {
                throw new ArgumentNullException("Contractor doesnt exist");
            }

            _contractorRepo.Delete(contractor);

            await _contractorRepo.SaveAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ContractorDTO>> GetAllContractorsAsync()
        {
            var contractors = await _contractorRepo.GetAllAsync();

            return _mapper.Map<IEnumerable<ContractorModel>, IEnumerable<ContractorDTO>>(contractors);
        }

        /// <inheritdoc/>
        public async Task<ContractorDTO> GetContractorAsync(int id)
        {
            var contractor = await _contractorRepo.GetFirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<ContractorModel, ContractorDTO>(contractor);
        }
    }
}
