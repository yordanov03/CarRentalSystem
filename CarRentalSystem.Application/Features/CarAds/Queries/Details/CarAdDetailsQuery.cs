using CarRentalSystem.Application.Features.Dealers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Features.CarAds.Queries.Details
{
    public class CarAdDetailsQuery : EntityCommand<int>, IRequest<CarAdDetailsOutputModel>
    {
        public class CarAdDetailsQueryHandler : IRequestHandler<CarAdDetailsQuery, CarAdDetailsOutputModel>
        {
            private readonly ICarAdRepository carAdRepository;
            private readonly IDealerRepository dealerRepository;

            public CarAdDetailsQueryHandler(
            ICarAdRepository carAdRepository,
            IDealerRepository dealerRepository)
            {
                this.carAdRepository = carAdRepository;
                this.dealerRepository = dealerRepository;
            }
            public async Task<CarAdDetailsOutputModel> Handle(CarAdDetailsQuery request, CancellationToken cancellationToken)
            {
                var carAdDetails = await carAdRepository.GetDetails(request.Id, cancellationToken);
                carAdDetails.Dealer = await dealerRepository.GetDetailsByCarId(carAdDetails.Id, cancellationToken);
                return carAdDetails;
            }
        }
    }
}
