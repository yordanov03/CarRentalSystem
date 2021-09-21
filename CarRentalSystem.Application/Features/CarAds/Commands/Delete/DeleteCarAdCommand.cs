using CarRentalSystem.Application.Common;
using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Application.Features.CarAds.Commands.Common;
using CarRentalSystem.Application.Features.Dealers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Features.CarAds.Queries.Delete
{
    public class DeleteCarAdCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteCarAdCommandHandler : IRequestHandler<DeleteCarAdCommand, Result>
        {
            private readonly ICarAdRepository carAdRepository;
            private readonly IDealerRepository dealerRepository;
            private readonly ICurrentUser currentUser;

            public DeleteCarAdCommandHandler(
                ICarAdRepository carAdRepository, 
                IDealerRepository dealerRepository,
                ICurrentUser currentUser)
            {
                this.carAdRepository = carAdRepository;
                this.currentUser = currentUser;
            }
            public async Task<Result> Handle(DeleteCarAdCommand request, CancellationToken cancellationToken)
            {
                var dealerHasCar = await this.currentUser.DealerHasCarAd(
                   this.dealerRepository,
                   request.Id,
                   cancellationToken);

                if (!dealerHasCar)
                {
                    return dealerHasCar;
                }

                return await this.carAdRepository.Delete(
                    request.Id,
                    cancellationToken);
            }
        }
    }
}
