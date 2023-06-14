using Medics.Entities;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medics.Context.EntityConfiguration
{
    public class IncomingEntityTypeConfiguration : IEntityTypeConfiguration<Incoming>
    {
        public void Configure(EntityTypeBuilder<Incoming> builder)
        {
            builder.ToTable("Incoming");
            builder.HasKey(x => x.Id);

            builder.HasIndex(iv => iv.InvoiceNo);

            builder.Property(sp => sp.SupplierName)
                   .IsRequired()
                   .HasMaxLength(50);           

            builder.Property(it => it.ItemName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(q => q.Quantity)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}