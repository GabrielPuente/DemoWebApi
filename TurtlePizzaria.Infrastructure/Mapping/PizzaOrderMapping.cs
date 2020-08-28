using TurtlePizzaria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TurtlePizzaria.Infrastructure.Mapping
{
    public class PizzaOrderMapping : IEntityTypeConfiguration<PizzaOrder>
    {
        public void Configure(EntityTypeBuilder<PizzaOrder> builder)
        {
            builder.ToTable("PIZZA_ORDER");
            builder.HasKey(x => new { x.PizzaId, x.OrderId });
            builder.HasOne(x => x.Pizza).WithMany(x => x.PizzaOrders).HasForeignKey(x => x.PizzaId);
            builder.HasOne(x => x.Order).WithMany(x => x.PizzaOrders).HasForeignKey(x => x.OrderId);
            builder.Property("DateRegister").IsRequired();
            builder.Property("Active").IsRequired();
        }
    }
}
