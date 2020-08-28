using TurtlePizzaria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TurtlePizzaria.Infrastructure.Mapping
{
    public class PizzaMapping : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.ToTable("PIZZA");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(4,2)").IsRequired();
            builder.CreateDefaultProperties();
        }
    }
}
