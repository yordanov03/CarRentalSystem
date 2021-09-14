namespace CarRentalSystem.Application.Features.CarAds
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using CarRentalSystem.Domain.Specifications;
    using Contracts;
    using Domain.Models.CarAds;
    using Queries.Search;

    public interface ICarAdRepository : IRepository<CarAd>
    {
        Task<IEnumerable<CarAdListingModel>> GetCarAdListings(
            Specification<CarAd> specification,
            CancellationToken cancellationToken = default);

        Task<int> Total(CancellationToken cancellationToken = default);
        Task<Category> GetCategory(int categoryId, CancellationToken cancellationToken = default);
        Task<Manufacturer> GetManufacturer(string manufacturer, CancellationToken cancellationToken = default);
    }
}
