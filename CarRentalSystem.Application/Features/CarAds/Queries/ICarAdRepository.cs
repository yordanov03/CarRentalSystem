﻿namespace CarRentalSystem.Application.Features.CarAds
{
    using CarRentalSystem.Application.Features.CarAds.Queries.Categories;
    using CarRentalSystem.Application.Features.CarAds.Queries.Common;
    using CarRentalSystem.Application.Features.CarAds.Queries.Details;
    using CarRentalSystem.Domain.Models.Dealers;
    using CarRentalSystem.Domain.Specifications;
    using Contracts;
    using Domain.Models.CarAds;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICarAdRepository : IRepository<CarAd>
    {
        Task<IEnumerable<TOutputModel>> GetCarAdListings<TOutputModel>(
            Specification<CarAd> carAdSpecification,
            Specification<Dealer> dealerSpecification,
            CarAdsSortOrder carAdsSortOrder,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);

        Task<int> Total(
            Specification<CarAd> carAdSpecification,
            Specification<Dealer> dealerSpecification,
            CancellationToken cancellationToken = default);
        Task<Category> GetCategory(int categoryId, CancellationToken cancellationToken = default);
        Task<Manufacturer> GetManufacturer(string manufacturer, CancellationToken cancellationToken = default);
        Task<IEnumerable<CategoryOutputModel>> GetCategories(CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
        Task<CarAdDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);
        Task<CarAd> Find(int id, CancellationToken cancellationToken = default);
    }
}
