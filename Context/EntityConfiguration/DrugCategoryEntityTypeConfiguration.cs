using Medics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Context.EntityConfiguration
{
    public class DrugCategoryEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<DrugCategory> builder)
        {
            builder.ToTable("DrugCategory");

                builder.HasKey(dc => dc.Id);

                builder.HasOne(dc => dc.Drug)
                       .WithMany(d => d.DrugCategory)
                       .HasForeignKey(d => d.DrugId)
                       .IsRequired();

                builder.HasOne(dc => dc.User)
                        .WithMany(c => c.Category)
                        .HasForeignKey(dc => dc.UserId)
                        .IsRequired();

                builder.HasMany(c => c.DrugCategories)
                       .WithOne(cr => cr.Drug)
                       .IsRequired();
            


        }
    }
}