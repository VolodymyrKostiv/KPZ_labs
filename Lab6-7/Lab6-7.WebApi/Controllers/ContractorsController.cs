using Lab6_7.DataAccess.Models;
using Lab6_7.DataAccess.Repositories.Interfaces;
using Lab6_7.DataAccess.Repositories.Realizations.Mocks;
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

        public ContractorsController(IContractorRepo contractorRepo)
        {
            _contractorRepo = contractorRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contractor>> GetAllContractors()
        {
            var contractorItems = _mock.GetAllContractors();

            return Ok(contractorItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Contractor> GetContractorById(int id)
        {
            var contractorItem = _mock.GetContractorById(id);

            return Ok(contractorItem);
        }
    }
}
