using Medics.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Context.EntityConfiguration
{
    public class AgeEntityTypeCnfiguration : IEntityTypeConfiguration<Age>
    {
        public void Configure(EntityTypeBuilder<Age> builder)
		{
			builder.ToTable("Age");

			builder.HasKey(a => a.Id);

            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(200);

		}
    }
}