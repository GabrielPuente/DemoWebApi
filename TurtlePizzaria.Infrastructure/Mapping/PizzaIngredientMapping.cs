using TurtlePizzaria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TurtlePizzaria.Infrastructure.Mapping
{
    public class PizzaIngredientMapping : IEntityTypeConfiguration<PizzaIngredient>
    {
        public void Configure(EntityTypeBuilder<PizzaIngredient> builder)
        {
            builder.ToTable("PIZZA_INGREDIENT");
            builder.HasKey(x => new { x.PizzaId, x.IngredientId });
            builder.HasOne(x => x.Pizza).WithMany(x => x.PizzaIngredients).HasForeignKey(x => x.PizzaId);
            builder.HasOne(x => x.Ingredient).WithMany(x => x.PizzaIngredients).HasForeignKey(x => x.IngredientId);
            builder.Property("DateRegister").IsRequired();
            builder.Property("Active").IsRequired();
        }
    }
}
