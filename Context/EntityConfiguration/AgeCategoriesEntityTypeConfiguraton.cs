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
                   .WithMany(a => a.AgeCategories)
                   .HasForeignKey(ag =>  ac.AgeId)
                   .IsRequired();

            builder.HasOne(ac => ac.User)
                    .WithMany(c => c.Categories)
                    .HasForeignKey(ac => ac.UserId)
                    .IsRequired();

            builder.HasMany(c => c.AgeCategories)
                   .WithOne(cr => cr.Age)
                   .IsRequired();
        }
    }
}