using Lab6_7.DataAccess.Models.Product;
using System;
using System.Collections.Generic;

namespace Lab6_7.DataAccess.Repositories.Realizations.Mocks
{
    public class MockProductRepo //: IProductRepo
    {
        public IEnumerable<ProductModel> GetAllProducts()
        {
            return new List<ProductModel>()
            {
                new ProductModel() { },
            };
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
