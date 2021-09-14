using AutoMapper;
using CarRentalSystem.Application.Mapping;
using CarRentalSystem.Domain.Models.CarAds;

namespace CarRentalSystem.Application.Features.CarAds.Queries.Search
{
    public class CarAdListingModel : IMapFrom<CarAd>
    {
        public string Manufacturer { get; private set; } = default!;

        public string Model { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public string Category { get; private set; } = default!;

        public decimal PricePerDay { get; private set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<CarAd, CarAdListingModel>()
                .ForMember(ad => ad.Manufacturer, cfg => cfg
                    .MapFrom(ad => ad.Manufacturer.Name))
                .ForMember(ad => ad.Category, cfg => cfg
                    .MapFrom(ad => ad.Category.Name));
    }
}
