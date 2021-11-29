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


        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of products</returns>
        /// <respone code="200">List of all products</respone>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productItems = await _productService.GetAllProductsAsync();

            return Ok(productItems);
        }


        /// <summary>
        /// Get product by his Id
        /// </summary>
        /// <param name="id">The id of product we want to find</param>
        /// <returns>Product model</returns>
        /// <response code="200">Product was found</response>
        /// <response code="404">Product with such id wasn't found</response>
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

        /// <summary>
        /// Create new product
        /// </summary>
        /// <param name="productDTO">New product data</param>
        /// <returns>Id of created product</returns>
        /// <response code="201">Product was created on route</response>
        /// <response code="400">Invalid product's data</response>
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
            catch (ArgumentException exc)
            {
                return BadRequest(exc.Message);
            }
            catch
            {
                return BadRequest();
            }

            var productViewModel = _mapper.Map<ProductDTO, ProductViewModel>(productDTO);

            return CreatedAtRoute(nameof(GetProductById), new { Id = productDTO.Id }, productViewModel);
        }

        /// <summary>
        /// Change product's data
        /// </summary>
        /// <param name="productDTO">New data for product</param>
        /// <param name="id">Id of the product we want to change</param>
        /// <returns>Status code</returns>
        /// <response code="200">Product was edited successfully</response>
        /// <response code="400">Invalid data for product (or it wasn't found)</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(int id, ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            try
            {
                await _productService.ChangeProductAsync(id, productDTO);
            }
            catch(ArgumentNullException exc)
            {
                return BadRequest(exc.Message);
            }
            catch (ArgumentException exc)
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
        /// Delete product
        /// </summary>
        /// <param name="id">The id of product we need to delete</param>
        /// <returns>Status code</returns>
        /// <response code="200">Product was deleted successfully</response>
        /// <response code="400">Product with such id wasn't found</response>
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
            catch (ArgumentException exc)
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
