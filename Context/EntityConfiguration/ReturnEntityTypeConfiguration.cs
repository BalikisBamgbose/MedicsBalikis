
using Medics.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Context.EntityConfiguration
{
    public class ReturnEntityTypeConfiguration : IEntityTypeConfiguration<Return>
    {
        public void Configure(EntityTypeBuilder<Return>builder)
        {
            builder.ToTable("Return");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.ReturnDate)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(q => q.Quantity)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.InvoiceNo)
                .IsRequired()
                .HasMaxLength(50);
           builder.HasKey(r => r.ReturnId);

            builder.Property(r => r.ReturnedBy)
                .IsRequired()
                .HasMaxLength(50);
        }
      
      
    }
}