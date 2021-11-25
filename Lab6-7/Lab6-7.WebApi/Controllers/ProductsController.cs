using AutoMapper;
using Lab6_7.BLL.DTOs.Product;
using Lab6_7.BLL.Interfaces.Product;
using Lab6_7.DataAccess.Models.Contractor;
using Lab6_7.DataAccess.Models.Product;
using Lab6_7.DataAccess.Repositories.Interfaces.Product;
using Lab6_7.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab6_7.WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetContractors()
        {
            var productItems = await _productService.GetAllProductsAsync();

            return Ok(productItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContractorById(int id)
        {
            var productItem = await _productService.GetProductAsync(id);

            if (productItem != null)
            {
                return Ok(_mapper.Map<ProductDTO, ProductViewModel>(productItem));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContractor(ProductViewModel productViewModel)
        {
            var productDto = _mapper.Map<ProductViewModel, ProductDTO>(productViewModel);

            await _productService.AddProductAsync(productDto);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditContractor(ProductViewModel productViewModel)
        {
            var productDto = _mapper.Map<ProductViewModel, ProductDTO>(productViewModel);

            await _productService.ChangeProductAsync(productDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveContractor(int id)
        {
            await _productService.DeleteProductAsync(id);

            return Ok();
        }
    }
}
