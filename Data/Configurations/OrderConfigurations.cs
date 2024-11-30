using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaritoShop.Model;
using Order = PizzaritoShop.Model.Order;

namespace PizzaritoShop.Data.Configurations
{
    //FLUENT API CONFIGURATIONS
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //This below places properties of ShippingAddress in the Order Table
            builder.OwnsOne(o => o.ShippingAddress, SAddress => SAddress.WithOwner());

            builder.Property(p => p.SubTotal)
                .HasColumnType("decimal(18,2)");
        }
    }
}
