using Lab6_7.BLL.DTOs.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab6_7.BLL.Interfaces.Product
{
    /// <summary>
    /// Defines operations to work with product
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Asynchronously get all of the products
        /// </summary>
        /// <returns>List of products</returns>
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();

        /// <summary>
        /// Asynchronously get the product by his Id
        /// </summary>
        /// <param name="id">The id of product we need to get</param>
        /// <returns>Found product</returns>
        Task<ProductDTO> GetProductAsync(int id);

        /// <summary>
        /// Asynchronously add new product
        /// </summary>
        /// <param name="productDTO">The data of new product</param>
        /// <returns>Nothing</returns>
        Task AddProductAsync(ProductDTO productDTO);

        /// <summary>
        /// Asynchronously change the data of specified product
        /// </summary>
        /// <param name="productDTO">The new data for product</param>
        /// <returns>Nothing</returns>
        Task ChangeProductAsync(ProductDTO productDTO);

        /// <summary>
        /// Asynchronously delete chosen product
        /// </summary>
        /// <param name="productDTO">The product we need to delete</param>
        /// <returns>Nothing</returns>
        Task DeleteProductAsync(ProductDTO productDTO);

        /// <summary>
        /// Asynchronously delete chosen product
        /// </summary>
        /// <param name="id">The id of contractor we need to delete</param>
        /// <returns>Nothing</returns>
        Task DeleteProductAsync(int id);
    }
}
