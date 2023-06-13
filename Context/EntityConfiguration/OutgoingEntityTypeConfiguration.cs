using Medics.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Context.EntityConfiguration
{
    public class OutgoingEntityTypeConfiguration : IEntityTypeConfiguration<Outgoing>
    {
       public void Configure(EntityTypeBuilder<Outgoing>builder) 
       {
            builder.ToTable("Outgoing");
            builder.HasKey(x => x.Id);

            builder.HasIndex(i => i.Item);

            builder.Property(p => p.Purpose)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(s => s.Sale);
            
            builder.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(q => q.Quantity)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.DeliveredTo)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}