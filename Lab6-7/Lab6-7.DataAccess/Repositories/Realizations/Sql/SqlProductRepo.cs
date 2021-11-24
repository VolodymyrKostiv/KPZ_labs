using Lab6_7.DataAccess.Models;
using Lab6_7.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_7.DataAccess.Repositories.Realizations.Sql
{
    public class SqlProductRepo : IProductRepo
    {
        private readonly LabDbContext _context;

        public SqlProductRepo(LabDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
