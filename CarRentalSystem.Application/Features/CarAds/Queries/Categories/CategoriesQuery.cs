using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Features.CarAds.Queries.Categories
{
    public class CategoriesQuery : IRequest<IEnumerable<CategoryOutputModel>>
    {
        public class CategoriesQueryHandler : IRequestHandler<CategoriesQuery, IEnumerable<CategoryOutputModel>>
        {
            private readonly ICarAdRepository carAdRepository;

            public CategoriesQueryHandler(ICarAdRepository carAdRepository)
                => this.carAdRepository = carAdRepository;

            public async Task<IEnumerable<CategoryOutputModel>> Handle(CategoriesQuery request, CancellationToken cancellationToken)
            => await this.carAdRepository.GetCategories(cancellationToken);
        }
    }
}
