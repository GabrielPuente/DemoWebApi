using Demo.Core.Data;
using Demo.Domain.Entities;
using Demo.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Demo.Infrastructure.Context
{
    public class DataContext : DbContext, IUnitOfWork
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options) { }

        public DbSet<User> Users { get; set; }

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
        }
    }
}