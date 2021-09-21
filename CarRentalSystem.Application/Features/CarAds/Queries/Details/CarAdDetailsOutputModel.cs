using AutoMapper;
using CarRentalSystem.Application.Features.CarAds.Queries.Common;
using CarRentalSystem.Application.Features.Dealers.Common;
using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Models.CarAds;

namespace CarRentalSystem.Application.Features.CarAds.Queries.Details
{
    public class CarAdDetailsOutputModel : CarAdOutputModel
    {

        public bool HasClimateControl { get; private set; }

        public int NumberOfSeats { get; private set; }

        public string TransmissionType { get; private set; } = default!;

        public DealerOutputModel Dealer { get; set; } = default!;

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<CarAd, CarAdDetailsOutputModel>()
                .IncludeBase<CarAd, CarAdOutputModel>()
                .ForMember(c => c.HasClimateControl, cfg => cfg
                    .MapFrom(c => c.Options.HasClimateControl))
                .ForMember(c => c.NumberOfSeats, cfg => cfg
                    .MapFrom(c => c.Options.NumberOfSeats))
                .ForMember(c => c.TransmissionType, cfg => cfg
                    .MapFrom(c => Enumeration.NameFromValue<TransmissionType>(
                        c.Options.TransmissionType.Value)));
    }
}
