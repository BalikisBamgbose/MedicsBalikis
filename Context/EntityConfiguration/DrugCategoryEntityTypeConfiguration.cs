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
    public class DrugCategoryEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<DrugCategory> builder)
        {
            builder.ToTable("DrugCategory");

                builder.HasKey(dc => dc.Id);

                builder.HasOne(dc => dc.Drug)
                   .WithMany(c => c.DrugCategory)
                   .HasForeignKey(dc => dc.UserId)
                   .IsRequired();


            builder.HasOne(dc => dc.Category)
                       .WithMany(d => d.DrugCategory)
                       .HasForeignKey(d => d.DrugId)
                       .IsRequired();

               
                


            
   
   
        }
    }
}