using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace CarRentalSystem.Application.Features.Dealers.Queries.Search
{
    public class SearchDealerQuery : IRequest<SearchDealerOutputModel>
    {
        public int Id { get; set; }


        public class SearchDealerQueryHandler : IRequestHandler<SearchDealerQuery, SearchDealerOutputModel>
        {
            private readonly IDealerRepository dealerRepository;

            public SearchDealerQueryHandler(IDealerRepository dealerRepository) 
                => this.dealerRepository = dealerRepository;

            public async Task<SearchDealerOutputModel> Handle(SearchDealerQuery request, CancellationToken cancellationToken)
            {
                var dealer = await this.dealerRepository.FindDealerById(request.Id, cancellationToken);

                return new SearchDealerOutputModel(dealer.Id, dealer.Name, dealer.PhoneNumber, dealer.CarAds.Count());
                
            }
        }
    }
}
