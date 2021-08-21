using CarRentalSystem.Domain.Models;
using CarRentalSystem.Domain.Models.CarAds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Infrastructure.Persistance.Configurations
{
    internal class CarAdConfiguration : IEntityTypeConfiguration<CarAd>
    {
        public void Configure(EntityTypeBuilder<CarAd> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Manufacturer).WithMany().HasForeignKey("ManufacturerId").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Category).WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Model).HasMaxLength(ModelConstants.CarAd.MaxModelLength).IsRequired();
            builder.Property(c => c.ImageUrl).IsRequired();
            builder.Property(c => c.PricePerDay).IsRequired();
            builder.Property(c => c.PricePerDay).IsRequired().HasColumnType("decimal(18,2)");
            builder.OwnsOne(c => c.Options, o =>
                {
                    o.WithOwner();

                    o.Property(op => op.NumberOfSeats);
                    o.Property(op => op.HasClimateControl);

                    o.OwnsOne(
                        op => op.TransmissionType,
                        t =>
                        {
                            t.WithOwner();

                            t.Property(tr => tr.Value);
                        });
                });
        }
    }
}
