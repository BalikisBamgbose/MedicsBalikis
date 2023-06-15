using Medics.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Context.EntityConfiguration
{
    public class DrugCategoryEntityTypeConfiguration : IEntityTypeConfiguration<DrugCategory>
    {
        public void Configure(EntityTypeBuilder<DrugCategory> builder)
        {
            builder.ToTable("DrugCategory");

                builder.HasKey(dc => dc.Id);

                builder.HasOne(dc => dc.Drug)
                   .WithMany(c => c.DrugCategorys)
                   .HasForeignKey(dc => dc.CategoryId)
                   .IsRequired();


            builder.HasOne(dc => dc.Category)
                       .WithMany(d => d.DrugCategorys)
                       .HasForeignKey(d => d.DrugId)
                       .IsRequired();
   
        }
    }
}