
using System.Reflection;
using Medics.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medics.Context
{
    public class MedicsContext : DbContext
    {
        public MedicsContext(DbContextOptions<MedicsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).DateCreated = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                    ((BaseEntity)entry.Entity).LastModified = DateTime.Now;
            }

            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity is ISoftDeletable && e.State == EntityState.Deleted))
            {
                entry.State = EntityState.Modified;
                entry.CurrentValues["IsDeleted"] = true;
            }

            return base.SaveChanges();
        }

            public DbSet<User> Users { get; set; }
            public DbSet<Category> Category { get; set; }
            public DbSet<Role> Roles { get; set; }
            public DbSet<Drug> Drugs { get; set; }
            public DbSet<DrugCategory> DrugCategory { get; set; }
            public DbSet<Incoming> Incomings { get; set; }
            public DbSet<Outgoing> Outgoing { get; set; } 
    
    }
}