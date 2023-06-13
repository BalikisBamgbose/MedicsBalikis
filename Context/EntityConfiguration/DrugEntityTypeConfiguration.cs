using Medics.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Context.EntityConfiguration
{
    public class DrugEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<Drug> builder)
        {
            builder.ToTable("Drug");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(d => d.Description)
             .IsUnique();
        }
    }
}