using AutoMapper;
using CarRentalSystem.Application.Features.CarAds.Queries.Common;
using CarRentalSystem.Domain.Models.CarAds;

namespace CarRentalSystem.Application.Features.CarAds.Queries.Mine
{
    public class MyCarAdOutputModel : CarAdOutputModel
    {
        public bool IsAvailable { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<CarAd, MyCarAdOutputModel>()
                .IncludeBase<CarAd, CarAdOutputModel>();
    }
}
