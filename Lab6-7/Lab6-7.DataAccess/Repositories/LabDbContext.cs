using Lab6_7.DataAccess.Models.Contractor;
using Lab6_7.DataAccess.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace Lab6_7.DataAccess.Repositories
{
    public class LabDbContext : DbContext
    {
        public LabDbContext(DbContextOptions<LabDbContext> opt) 
            : base(opt)
        {
        }

        public DbSet<ContractorModel> Contractors { get; set; }
        public DbSet<ProductModel> Products { get; set; }
    }
}
