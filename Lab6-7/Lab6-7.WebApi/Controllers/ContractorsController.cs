using AutoMapper;
using Lab6_7.DataAccess.Models;
using Lab6_7.DataAccess.Repositories.Interfaces;
using Lab6_7.DataAccess.Repositories.Realizations.Mocks;
using Lab6_7.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6_7.WebApi.Controllers
{
    [Route("api/contractors")]
    [ApiController]
    public class ContractorsController : ControllerBase
    {
        private readonly MockContractorsRepo _mock = new MockContractorsRepo();
        private readonly IContractorRepo _contractorRepo;
        private readonly IMapper _mapper;

        public ContractorsController(IContractorRepo contractorRepo, IMapper mapper)
        {
            _contractorRepo = contractorRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contractor>> GetAllContractors()
        {
            var contractorItems = _contractorRepo.GetAllContractors();

            return Ok(contractorItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Contractor> GetContractorById(int id)
        {
            var contractorItem = _contractorRepo.GetContractorById(id);
            
            if (contractorItem != null)
            {
                var contractorMappedItem = _mapper.Map<ContractorViewModel>(contractorItem);
                return Ok();
            }

            return NotFound();
        }
    }
}
