using Medics.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Context.EntityConfiguration
{
    public class AgeCategoriesEntityTypeConfiguraton : IEntityTypeConfiguration<AgeCategories>
    {
        public void Configure(EntityTypeBuilder<AgeCategories> builder)
        {
            builder.ToTable("AgeCategories");

            builder.HasKey(ac => ac.Id);
            

            builder.HasOne(ac => ac.Age)
                   .WithMany(ac => ac.AgeCategories)
                   .HasForeignKey(ag => ag.AgeId)
                   .IsRequired();

            builder.HasOne(ac => ac.Categories)
                    .WithMany(a => a.AgeCategories)
                    .HasForeignKey(ag => ag.CategoriesId)
                    .IsRequired();

        }
    }
}