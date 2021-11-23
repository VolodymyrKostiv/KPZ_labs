using Lab6_7.DataAccess.Models;
using Lab6_7.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_7.DataAccess.Repositories.Realizations.Mocks
{
    public class MockProductRepo : IProductRepo
    {
        public IEnumerable<Product> GetAllProducts()
        {
            return new List<Product>()
            {
                new Product() { },
            };
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
