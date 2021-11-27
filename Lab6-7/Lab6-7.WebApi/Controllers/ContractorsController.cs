using AutoMapper;
using Lab6_7.BLL.DTOs.Contractor;
using Lab6_7.BLL.Interfaces.Contractor;
using Lab6_7.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("{id}", Name="GetContractorById")]
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
        public async Task<IActionResult> CreateContractor(ContractorDTO contractorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            try
            {
                await _contractorService.AddContractorAsync(contractorDTO);
            }
            catch
            {
                return BadRequest();
            }

            var contractorModel = _mapper.Map<ContractorDTO, ContractorViewModel>(contractorDTO);

            return CreatedAtRoute(nameof(GetContractorById), new { Id = contractorDTO.Id }, contractorModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditContractor(ContractorDTO contractorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            try
            {
                await _contractorService.ChangeContractorAsync(contractorDTO);
            }
            catch (ArgumentNullException exc)
            {
                return BadRequest(exc.Message);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveContractor(int id)
        {
            try
            {
                await _contractorService.DeleteContractorAsync(id);
            }
            catch (ArgumentNullException exc)
            {
                return BadRequest(exc.Message);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
