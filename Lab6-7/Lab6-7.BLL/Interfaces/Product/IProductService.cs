using Lab6_7.BLL.DTOs.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab6_7.BLL.Interfaces.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();

        Task<ProductDTO> GetProductAsync(int id);

        Task AddProductAsync(ProductDTO productDTO);

        Task ChangeProductAsync(ProductDTO productDTO);

        Task DeleteProductAsync(int id);

        Task DeleteProductAsync(ProductDTO productDTO);
    }
}
