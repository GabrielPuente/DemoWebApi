using TurtlePizzaria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TurtlePizzaria.Infrastructure.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("ORDER");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Price).HasColumnType("decimal(4,2)").IsRequired();
            builder.Property(x => x.Comment).HasMaxLength(255);
            builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
            builder.CreateDefaultProperties();
        }
    }
}
