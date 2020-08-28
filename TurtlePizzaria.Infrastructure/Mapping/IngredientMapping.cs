using TurtlePizzaria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TurtlePizzaria.Infrastructure.Mapping
{
    public class IngredientMapping : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("INGREDIENT");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(4,2)").IsRequired();
            builder.CreateDefaultProperties();
        }
    }
}
