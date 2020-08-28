using TurtlePizzaria.Core.Data;
using TurtlePizzaria.Domain.Entities;
using TurtlePizzaria.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace TurtlePizzaria.Infrastructure.Context
{
    public class DataContext : DbContext, IUnitOfWork
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PizzaIngredient> PizzaIngredients { get; set; }
        public DbSet<PizzaOrder> PizzaOrders { get; set; }

        public bool Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateRegister") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DateRegister").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DateRegister").IsModified = false;
            }
            return base.SaveChanges() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new PizzaMapping());
            modelBuilder.ApplyConfiguration(new IngredientMapping());
            modelBuilder.ApplyConfiguration(new OrderMapping());
            modelBuilder.ApplyConfiguration(new PizzaIngredientMapping());
            modelBuilder.ApplyConfiguration(new PizzaOrderMapping());
        }
    }
}