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
            builder.HasIndex(s => s.SupplierName);
            builder.HasIndex(i => i.ItemName);
            builder.HasIndex(iv => iv.InvoiceNo);
            builder.HasIndex(q => q.Quantity);

        }
    }
}