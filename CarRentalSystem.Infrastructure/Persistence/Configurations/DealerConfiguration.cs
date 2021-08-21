using CarRentalSystem.Domain.Models;
using CarRentalSystem.Domain.Models.Dealers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Infrastructure.Persistance.Configurations
{
    internal class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.HasKey(d => d.Id);

            builder
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(ModelConstants.Common.MaxNameLength);

            builder
                .OwnsOne(
                    d => d.PhoneNumber,
                    p =>
                    {
                        p.WithOwner();

                        p.Property(pn => pn.Number);
                    });

            builder
                .HasMany(pr => pr.CarAds)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("carAds");
        }
    }
}
