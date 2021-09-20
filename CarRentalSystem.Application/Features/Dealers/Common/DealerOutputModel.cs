using AutoMapper;
using CarRentalSystem.Application.Mapping;
using CarRentalSystem.Domain.Models.Dealers;

namespace CarRentalSystem.Application.Features.Dealers.Common
{
    public class DealerOutputModel : IMapFrom<Dealer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public virtual void Mapping(Profile mapper)
            => mapper.CreateMap<Dealer, DealerOutputModel>()
            .ForMember(d => d.PhoneNumber, cfg => cfg
              .MapFrom(d => d.PhoneNumber.Number));
    }
}
