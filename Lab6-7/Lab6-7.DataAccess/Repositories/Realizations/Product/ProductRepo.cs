using Lab6_7.DataAccess.Models.Product;
using Lab6_7.DataAccess.Repositories.Interfaces.Product;
using Lab6_7.DataAccess.Repositories.Realizations.Base;

namespace Lab6_7.DataAccess.Repositories.Realizations.Product
{
    public class ProductRepo : RepositoryBase<ProductModel>, IProductRepo
    {
        public ProductRepo(LabDbContext context) 
            : base(context)
        {
        }
    }
}
