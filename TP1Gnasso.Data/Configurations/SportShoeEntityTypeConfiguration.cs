using TP1Gnasso.Entities;
//using EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;

namespace TP1Gnasso.Data.Configurations
{
    public class SportShoeEntityTypeConfiguration : IEntityTypeConfiguration<SportShoe>
    {
        public void Configure(EntityTypeBuilder<SportShoe> builder)
        {
            builder.HasKey(ss => ss.SportShoeId);

            builder.Property(ss => ss.Model)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ss => ss.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(ss => ss.ReleaseDate)
                .IsRequired();

            builder.Property(ss => ss.Active)
                .HasDefaultValue(true);

            builder.HasOne(ss => ss.Brand)
                .WithMany()
                .HasForeignKey(ss => ss.BrandId);

            builder.HasOne(ss => ss.Size)
                .WithMany()
                .HasForeignKey(ss => ss.SizeId);

            builder.HasOne(ss => ss.Sport)
                .WithMany()
                .HasForeignKey(ss => ss.SportId);

            builder.HasOne(ss => ss.Genre)
                .WithMany()
                .HasForeignKey(ss => ss.GenreId);

            builder.HasIndex(ss => new { ss.Model, ss.SizeId }, "IX_SportShoes_Model_SizeId").IsUnique();
        
            builder.Property(ss => ss.RowVersion).IsRowVersion();
        }
    }
}
