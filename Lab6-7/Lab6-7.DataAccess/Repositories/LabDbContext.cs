using Lab6_7.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_7.DataAccess.Repositories
{
    public class LabDbContext : DbContext
    {
        public LabDbContext(DbContextOptions<LabDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder
            //    .Entity<Contractor>()
            //    .HasMany(x => x.Contacts);

            //modelBuilder
            //    .Entity<Contractor>()
            //    .HasMany(x => x.TechSkills);

            //modelBuilder
            //    .Entity<Contractor>()
            //    .HasMany(x => x.SoftSkills);
        }

        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
