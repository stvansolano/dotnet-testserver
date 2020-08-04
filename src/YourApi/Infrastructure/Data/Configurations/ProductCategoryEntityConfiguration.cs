namespace YourApi.Infrastructure.Data.Configurations
{
    using Models;
    using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class ProductCategoryEntityConfiguration
            : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> entity)
        {
            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(1);

            entity.Property(e => e.ParentProductCategoryId).HasColumnName("ParentProductCategoryID");

            entity.Property(e => e.Rowguid).HasColumnName("rowguid");
        }
	}
}