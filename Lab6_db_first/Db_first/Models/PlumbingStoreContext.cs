using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Db_first.Models
{
    public partial class PlumbingStoreContext : DbContext
    {
        public PlumbingStoreContext()
        {
        }

        public PlumbingStoreContext(DbContextOptions<PlumbingStoreContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Server=...;Database=LabWebApiDB;Trusted_Connection=true;
        /// </summary>

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductBrand> ProductBrands { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public virtual DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public virtual DbSet<ProductUnit> ProductUnits { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual DbSet<Specification> Specifications { get; set; }
        public virtual DbSet<VOrdersInfo> VOrdersInfos { get; set; }
        public virtual DbSet<VProductInfo> VProductInfos { get; set; }
        public virtual DbSet<VSubcategoriesAndCategory> VSubcategoriesAndCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-30PG5K8;Database=PlumbingStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.CustomerTypeId).HasColumnName("CustomerTypeID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(17);

                entity.HasOne(d => d.CustomerType)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CustomerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_CustomerType");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.ToTable("CustomerType");

                entity.Property(e => e.CustomerTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProductBrandId).HasColumnName("ProductBrandID");

                entity.Property(e => e.ProductSubcategoryId).HasColumnName("ProductSubcategoryID");

                entity.Property(e => e.ProductUnitId).HasColumnName("ProductUnitID");

                entity.HasOne(d => d.ProductBrand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductBrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductBrand");

                entity.HasOne(d => d.ProductSubcategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductSubcategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductSubcategory");

                entity.HasOne(d => d.ProductUnit)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductUnit");
            });

            modelBuilder.Entity<ProductBrand>(entity =>
            {
                entity.ToTable("ProductBrand");

                entity.Property(e => e.ProductBrandId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductBrandID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");

                entity.Property(e => e.ProductCategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductCategoryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<ProductSpecification>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.SpecificationId });

                entity.ToTable("ProductSpecification");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SpecificationId).HasColumnName("SpecificationID");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSpecifications)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductSpecification_Product");

                entity.HasOne(d => d.Specification)
                    .WithMany(p => p.ProductSpecifications)
                    .HasForeignKey(d => d.SpecificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductSpecification_Specification");
            });

            modelBuilder.Entity<ProductSubcategory>(entity =>
            {
                entity.ToTable("ProductSubcategory");

                entity.Property(e => e.ProductSubcategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductSubcategoryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.ProductSubcategories)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductSubcategory_ProductCategory");
            });

            modelBuilder.Entity<ProductUnit>(entity =>
            {
                entity.ToTable("ProductUnit");

                entity.Property(e => e.ProductUnitId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductUnitID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.ToTable("ShoppingCart");

                entity.Property(e => e.ShoppingCartId)
                    .ValueGeneratedNever()
                    .HasColumnName("ShoppingCartID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_ShoppingCart_Customer");
            });

            modelBuilder.Entity<ShoppingCartItem>(entity =>
            {
                entity.ToTable("ShoppingCartItem");

                entity.Property(e => e.ShoppingCartItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("ShoppingCartItemID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ShoppingCartId).HasColumnName("ShoppingCartID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShoppingCartItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingCartItem_Product");

                entity.HasOne(d => d.ShoppingCart)
                    .WithMany(p => p.ShoppingCartItems)
                    .HasForeignKey(d => d.ShoppingCartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingCartItem_ShoppingCart");
            });

            modelBuilder.Entity<Specification>(entity =>
            {
                entity.ToTable("Specification");

                entity.Property(e => e.SpecificationId)
                    .ValueGeneratedNever()
                    .HasColumnName("SpecificationID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VOrdersInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vOrdersInfo");

                entity.Property(e => e.Customer).HasMaxLength(100);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.Property(e => e.ToPay).HasColumnName("To pay");

                entity.Property(e => e.Type).HasMaxLength(20);
            });

            modelBuilder.Entity<VProductInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vProductInfo");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Product name");

                entity.Property(e => e.Subcategory)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<VSubcategoriesAndCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vSubcategoriesAndCategories");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("Category name");

                entity.Property(e => e.SubcategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Subcategory name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
