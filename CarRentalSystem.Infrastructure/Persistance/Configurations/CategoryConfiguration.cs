using CarRentalSystem.Domain.Models.CarAds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CarRentalSystem.Domain.Models.ModelConstants.Common;
using static CarRentalSystem.Domain.Models.ModelConstants.Category;

namespace CarRentalSystem.Infrastructure.Persistance.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(MaxNameLength);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(MaxDescriptionLength);
        }
    }
}
