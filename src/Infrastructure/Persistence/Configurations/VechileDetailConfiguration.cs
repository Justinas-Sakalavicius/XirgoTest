using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Infrastructure.Persistence.Configurations
{
    public class VechileDetailConfiguration : IEntityTypeConfiguration<VechileDetail>
    {
        public void Configure(EntityTypeBuilder<VechileDetail> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(d => d.Latitude)
                .IsRequired()
                .HasDefaultValueSql("((0))");

            builder.Property(d => d.Longitude)
                .IsRequired()
                .HasDefaultValueSql("((0))");

            builder.Property(d => d.Speed)
                .HasDefaultValueSql("((0))");

            builder.HasOne(d => d.Vechile)
               .WithMany(p => p.Details)
               .HasForeignKey(d => d.VechileId);
        }
    }
}
