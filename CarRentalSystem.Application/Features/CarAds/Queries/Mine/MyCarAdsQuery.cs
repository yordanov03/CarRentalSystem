using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Application.Features.CarAds.Queries.Common;
using CarRentalSystem.Application.Features.Dealers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Features.CarAds.Queries.Mine
{
    public class MyCarAdsQuery : CarAdsQuery, IRequest<MyCarAdsOutputModel>
    {
        public class MyCarAdsQueryHandler : CarAdsQueryHandler, IRequestHandler<MyCarAdsQuery, MyCarAdsOutputModel>
        {
            private readonly IDealerRepository dealerRepository;
            private readonly ICurrentUser currentUser;

            public MyCarAdsQueryHandler(ICarAdRepository carAdRepository,
                IDealerRepository dealerRepository,
                ICurrentUser currentUser)
                : base(carAdRepository)
            {
                this.currentUser = currentUser;
                this.dealerRepository = dealerRepository;
            }
            public async Task<MyCarAdsOutputModel> Handle(MyCarAdsQuery request, CancellationToken cancellationToken)
            {
                var dealerId = await this.dealerRepository.GetDealerId(this.currentUser.UserId);
                var carAdListings = await base.GetCarAdListings<MyCarAdOutputModel>(
                    request,
                    onlyAvailable: true,
                    dealerId,
                    cancellationToken);

                var totalPages = await base.GetTotalPages(
                    request,
                    onlyAvailable: false,
                    dealerId,
                    cancellationToken);

                return new MyCarAdsOutputModel(carAdListings, request.Page, totalPages);
            }
        }
    }
}
