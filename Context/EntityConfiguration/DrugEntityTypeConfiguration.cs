using Medics.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Context.EntityConfiguration
{
    public class DrugEntityTypeConfiguration : IEntityTypeConfiguration<Drug>
    {
        public void Configure(EntityTypeBuilder<Drug> builder)
        {
            builder.ToTable("Drug");
            builder.HasKey(x => x.Id);

            builder.HasOne(u => u.User)
                   .WithMany(d => d.Drug)
                   .HasForeignKey(q => q.UserId);
                  

          builder.Property(d => d.Description)
                .HasMaxLength(50);

            builder.HasMany(a => a.DrugCategorys)
                 .WithOne(a => a.Drug);
                 

            builder.HasIndex(d => d.Prices);

            builder.HasIndex(d => d.Quantity);

            builder.Property(d => d.ImageUrl)
                .HasColumnType("varchar(255)");
        }

    }
}