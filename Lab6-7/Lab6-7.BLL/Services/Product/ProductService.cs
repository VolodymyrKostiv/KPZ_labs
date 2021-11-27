﻿using AutoMapper;
using Lab6_7.BLL.DTOs.Product;
using Lab6_7.BLL.Interfaces.Product;
using Lab6_7.DataAccess.Models.Product;
using Lab6_7.DataAccess.Repositories.Interfaces.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab6_7.BLL.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;

        public ProductService(
            IProductRepo productRepo,
            IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task AddProductAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<ProductDTO, ProductModel>(productDTO);

            if (product == null)
            {
                throw new ArgumentException("Exception just for fun");
            }

            await _productRepo.CreateAsync(product);

            await _productRepo.SaveAsync();
        }

        public async Task ChangeProductAsync(ProductDTO productDTO)
        {
            var product = await _productRepo.GetFirstOrDefaultAsync(c => c.Id == productDTO.Id);

            if (product == null)
            {
                throw new ArgumentNullException("Product doesn't exist");
            }

            _productRepo.Update(product);

            await _productRepo.SaveAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepo.GetFirstOrDefaultAsync(c => c.Id == id);

            if (product == null)
            {
                throw new ArgumentNullException("Product doesn't exist");
            }

            _productRepo.Delete(product);

            await _productRepo.SaveAsync();
        }

        public async Task DeleteProductAsync(ProductDTO productDTO)
        {
            var product = await _productRepo.GetFirstOrDefaultAsync(c => c.Id == productDTO.Id);

            if (product == null)
            {
                throw new ArgumentNullException("Product doesn't exist");
            }

            _productRepo.Delete(product);

            await _productRepo.SaveAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepo.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductModel>, IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductAsync(int id)
        {
            var product = await _productRepo.GetFirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<ProductModel, ProductDTO>(product);
        }
    }
}
