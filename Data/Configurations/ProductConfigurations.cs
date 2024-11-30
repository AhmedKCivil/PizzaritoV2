using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaritoShop.Model;

namespace PizzaritoShop.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
           
            builder.Property(p => p.Description)
               .IsRequired();

            builder.Property(p => p.ImageCover)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}



