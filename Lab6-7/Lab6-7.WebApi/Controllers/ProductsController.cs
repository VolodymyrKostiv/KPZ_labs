using AutoMapper;
using Lab6_7.BLL.DTOs.Product;
using Lab6_7.BLL.Interfaces.Product;
using Lab6_7.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> GetProducts()
        {
            var productItems = await _productService.GetAllProductsAsync();

            return Ok(productItems);
        }

        [HttpGet("{id}", Name="GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var productItem = await _productService.GetProductAsync(id);

            if (productItem != null)
            {
                return Ok(_mapper.Map<ProductDTO, ProductViewModel>(productItem));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await _productService.AddProductAsync(productDTO);
            }
            catch
            {
                return BadRequest();
            }

            var productViewModel = _mapper.Map<ProductDTO, ProductViewModel>(productDTO);

            return CreatedAtRoute(nameof(GetProductById), new { Id = productDTO.Id }, productViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            try
            {
                await _productService.ChangeProductAsync(productDTO);
            }
            catch(ArgumentNullException exc)
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
        public async Task<IActionResult> RemoveProduct(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
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
