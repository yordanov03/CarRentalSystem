using AutoMapper;
using CarRentalSystem.Application.Features.Dealers.Common;
using CarRentalSystem.Domain.Models.Dealers;
using System.Linq;

namespace CarRentalSystem.Application.Features.Dealers.GetDealers
{
    public class DealerDetailsOutputModel : DealerOutputModel
    {
        public int TotalCarAds { get; set; }

        public override void Mapping(Profile mapper)
        {
            mapper.CreateMap<Dealer, DealerDetailsOutputModel>()
                .IncludeBase<Dealer, DealerOutputModel>()
                .ForMember(d => d.TotalCarAds, cfg => cfg
                  .MapFrom(d => d.CarAds.Count()));
        }
    }
}
