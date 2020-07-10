using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Infrastructure.Persistence.Configurations
{
    public class VechileConfiguration : IEntityTypeConfiguration<Vechile>
    {
        public void Configure(EntityTypeBuilder<Vechile> builder)
        {
            builder.Property(v => v.LicensePlate)
                .IsRequired()
                .HasMaxLength(6);

            builder.Property(v => v.BrandName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(v => v.ModelName)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}
