using CarRentalSystem.Application.Mapping;
using CarRentalSystem.Domain.Models.CarAds;

namespace CarRentalSystem.Application.Features.CarAds.Queries.Categories
{
    public class CategoryOutputModel : IMapFrom<Category>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int TotalCarAds { get; set; }
    }
}
