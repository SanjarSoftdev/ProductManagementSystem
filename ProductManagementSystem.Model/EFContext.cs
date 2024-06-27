using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Model.Entities;

namespace ProductManagementSystem.Model
{
    public class EFContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<UnitMeasure> UnitMeasures { get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public override int SaveChanges()
        {
            SetDefaultZnakSystem();
            return base.SaveChanges();
        }

        private void SetDefaultZnakSystem()
        {
            foreach (var entry in ChangeTracker.Entries<User>())
            {
                if (entry.State == EntityState.Added)
                {

                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(Helper.DBConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ProductCategoryModelMapping(modelBuilder);
            UnitMeasureModelMapping(modelBuilder);
        }

        void ProductCategoryModelMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.Products)
                .WithOne(p => p.ProductCategory)
                .HasForeignKey(p => p.ProductCategoryId);
        }


        void UnitMeasureModelMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UnitMeasure>()
                .HasMany(u => u.Products)
                .WithOne(p => p.UnitMeasure)
                .HasForeignKey(p => p.UnitMeasureId);
        }
    }
}
