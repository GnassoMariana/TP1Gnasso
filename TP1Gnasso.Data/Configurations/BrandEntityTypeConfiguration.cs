using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities;

namespace TP1Gnasso.Data.Configurations
{
    public class BrandEntityTypeConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.BrandId);

            builder.Property(b => b .Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Country)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Active)
                .HasDefaultValue(true);

            builder.HasIndex(b => b.Name, "IX:Brands_Name").IsUnique();
            builder.Property(b => b.RowVersion).IsRowVersion();

        }
    }
}
