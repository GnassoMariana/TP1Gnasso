using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities;

namespace TP1Gnasso.Data.Configurations
{
    public class SizeEntityTypeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(s => s.SizeId);

            builder.Property(s => s.Number)
                .HasColumnType("decimal(5,2)");

            builder.Property(s => s.Active)
                .HasDefaultValue(true);

            builder.HasIndex(s => s.Number, "IX_Sizes_Number").IsUnique();
            builder.Property(s => s.RowVersion).IsRowVersion();

        }
    }
}
