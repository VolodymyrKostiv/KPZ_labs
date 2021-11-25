using AutoMapper;
using Lab6_7.BLL.DTOs.Contractor;
using Lab6_7.BLL.Interfaces.Contractor;
using Lab6_7.DataAccess.Models.Contractor;
using Lab6_7.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab6_7.WebApi.Controllers
{
    [Route("api/contractors")]
    [ApiController]
    public class ContractorsController : ControllerBase
    {
        private readonly IContractorService _contractorService;
        private readonly IMapper _mapper;

        public ContractorsController(IContractorService contractorService, IMapper mapper)
        {
            _contractorService = contractorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetContractors()
        {
            var contractorItems = await _contractorService.GetAllContractorsAsync();

            return Ok(contractorItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContractorById(int id)
        {
            var contractorItem = await _contractorService.GetContractorAsync(id);

            if (contractorItem != null)
            {
                return Ok(_mapper.Map<ContractorDTO, ContractorViewModel>(contractorItem));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContractor(ContractorViewModel contractorViewModel)
        {
            var contractorDto = _mapper.Map<ContractorViewModel, ContractorDTO>(contractorViewModel);

            await _contractorService.AddContractorAsync(contractorDto);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditContractor(ContractorViewModel contractorViewModel)
        {
            var contractorDto = _mapper.Map<ContractorViewModel, ContractorDTO>(contractorViewModel);

            await _contractorService.ChangeContractorAsync(contractorDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveContractor(int id)
        {
            await _contractorService.DeleteContractorAsync(id);

            return Ok();
        }
    }
}
