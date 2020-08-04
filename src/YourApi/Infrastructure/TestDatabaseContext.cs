namespace YourApi.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Models;
	using Infrastructure.Data.Configurations;

	public partial class TestDatabaseContext : DbContext
    {
        public TestDatabaseContext() { }

        public TestDatabaseContext(DbContextOptions<TestDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProductCategory> ProductCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductCategoryEntityConfiguration());
        }
    }

    public class DbContextDesignFactory : IDesignTimeDbContextFactory<TestDatabaseContext>
    {
        public TestDatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder =  new DbContextOptionsBuilder<TestDatabaseContext>()
                .UseSqlServer("");

            return new TestDatabaseContext(optionsBuilder.Options);
        }
    }
}
