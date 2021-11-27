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

        /// <summary>
        /// Get all contractors
        /// </summary>
        /// <returns>List of contractors</returns>
        /// <response code="200">List of all contractors</response>
        [HttpGet]
        public async Task<IActionResult> GetContractors()
        {
            var contractorItems = await _contractorService.GetAllContractorsAsync();

            return Ok(contractorItems);
        }

        /// <summary>
        /// Get contractor by his Id
        /// </summary>
        /// <param name="id">The id of contractor we want to find</param>
        /// <returns>Contractor model</returns>
        /// <response code="200">Contractor was found</response>
        /// <response code="404">User with such id wasn't found</response>
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

        /// <summary>
        /// Create new contractor
        /// </summary>
        /// <param name="contractorDTO">New contractor data</param>
        /// <returns>Id of created contractor</returns>
        /// <response code="201">Contractor was created on route</response>
        /// <response code="400">Invalid contactor's data</response>
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

        /// <summary>
        /// Change contactor's data
        /// </summary>
        /// <param name="contractorDTO">New data for contractor</param>
        /// <returns>Status code</returns>
        /// <response code="200">Contractor was edited successfully</response>
        /// <response code="400">Invalid data for contractor (or it wasn't found)</response>

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

        /// <summary>
        /// Delete contractor
        /// </summary>
        /// <param name="id">The id of contractor we need to delete</param>
        /// <returns>Status code</returns>
        /// <response code="200">Contractor was deleted successfully</response>
        /// <response code="400">Contractor with such id wasn't found</response>
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
