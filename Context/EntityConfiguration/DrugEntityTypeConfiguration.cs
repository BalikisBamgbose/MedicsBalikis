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


            builder.HasMany(d => d.DrugCategory);
            builder.HasOne(u => u.UserId);            

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(d => d.Prices);

            builder.HasIndex(d => d.Quantity);

            builder.Property(d => d.ImageUrl)
                .HasColumnType("varchar(255)");
        }
        
    }
}