using CarRentalSystem.Application.Features.CarAds.Queries.Common;
using CarRentalSystem.Domain.Specifications.CarAds;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static CarRentalSystem.Application.Features.CarAds.Queries.Common.CarAdsQuery;

namespace CarRentalSystem.Application.Features.CarAds.Queries.Search
{
    public class SearchCarAdsQuery : CarAdsQuery, IRequest<SearchCarAdsOutputModel>
    {
        public class SearchCarAdsQueryHandler : CarAdsQueryHandler, IRequestHandler<SearchCarAdsQuery, SearchCarAdsOutputModel>
        {
            private readonly ICarAdRepository carAdRepository;

            public SearchCarAdsQueryHandler(ICarAdRepository carAdRepository) : base(carAdRepository) { }
                

            public async Task<SearchCarAdsOutputModel> Handle(
                SearchCarAdsQuery request,
                CancellationToken cancellationToken)
            {
                var carAdSpecification = new CarAdByManufacturerSpecification(request.Manufacturer)
                    .And(new CarAdByCategorySpecification(request.Category))
                    .And(new CarAdByPricePerDaySpecification(request.MinPricePerDay, request.MaxPricePerDay));

                var carAdListings = await base.GetCarAdListings<CarAdOutputModel>(
                    request,
                    cancellationToken: cancellationToken);

                var totalPages = await base.GetTotalPages(
                    request,
                    cancellationToken: cancellationToken);

                return new SearchCarAdsOutputModel(carAdListings, request.Page, totalPages);
            }
        }
    }
}
