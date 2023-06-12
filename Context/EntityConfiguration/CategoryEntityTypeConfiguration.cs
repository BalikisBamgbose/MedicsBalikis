using Medics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Context.EntityConfiguration
{
    public class CategoryEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(c => c.Name)
             .IsUnique();

            builder.Property(c => c.Description)
                .HasMaxLength(200);
        }
    }
}