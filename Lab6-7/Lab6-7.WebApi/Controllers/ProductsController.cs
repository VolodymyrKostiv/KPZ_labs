using AutoMapper;
using Lab6_7.DataAccess.Models;
using Lab6_7.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6_7.WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepo contractorRepo, IMapper mapper)
        {
            _productRepo = contractorRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllContractors()
        {
            var productItem = _productRepo.GetAllProducts();

            return Ok(productItem);
        }

        [HttpGet("{id}")]
        public ActionResult<Contractor> GetContractorById(int id)
        {
            var productItem = _productRepo.GetProductById(id);

            if (productItem != null)
            {
                return Ok(productItem);
            }
            return NotFound();
        }
    }
}
