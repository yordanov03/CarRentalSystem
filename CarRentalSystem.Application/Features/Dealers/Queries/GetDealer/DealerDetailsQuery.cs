using CarRentalSystem.Application.Features.Dealers.GetDealers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Features.Dealers.GetDealer
{
    public class DealerDetailsQuery : IRequest<DealerDetailsOutputModel>
    {
        public int Id { get; set; }

        public class DealerDetailsQueryHandler : IRequestHandler<DealerDetailsQuery, DealerDetailsOutputModel>
        {
            private readonly IDealerRepository dealerRepository;

            public DealerDetailsQueryHandler(IDealerRepository dealerRepository)
                => this.dealerRepository = dealerRepository;

            public async Task<DealerDetailsOutputModel> Handle(DealerDetailsQuery request, CancellationToken cancellationToken)
                => await this.dealerRepository.FindDealerById(request.Id, cancellationToken);
        }
    }
}
