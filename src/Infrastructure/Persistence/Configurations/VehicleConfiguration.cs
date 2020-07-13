using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Infrastructure.Persistence.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
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
