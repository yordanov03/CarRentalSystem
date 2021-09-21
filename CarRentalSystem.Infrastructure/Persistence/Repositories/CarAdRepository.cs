namespace CarRentalSystem.Infrastructure.Persistence.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Features.CarAds;
    using Application.Features.CarAds.Queries.Search;
    using AutoMapper;
    using CarRentalSystem.Application.Features.CarAds.Queries.Categories;
    using CarRentalSystem.Application.Features.CarAds.Queries.Common;
    using CarRentalSystem.Application.Features.CarAds.Queries.Details;
    using CarRentalSystem.Domain.Models.Dealers;
    using CarRentalSystem.Domain.Specifications;
    using CarRentalSystem.Infrastructure.Common;
    using CarRentalSystem.Infrastructure.Persistance;
    using Domain.Models.CarAds;
    using Microsoft.EntityFrameworkCore;

    internal class CarAdRepository : DataRepository<CarAd>, ICarAdRepository
    {
        private readonly IMapper mapper;

        public CarAdRepository(CarRentalDbContext db, IMapper mapper)
            : base(db)
        => this.mapper = mapper;

        public async Task<IEnumerable<TOutputModel>> GetCarAdListings<TOutputModel>(
                    Specification<CarAd> carAdSpecification,
                    Specification<Dealer> dealerSpecification,
                    CarAdsSortOrder carAdsSortOrder,
                    int skip = 0,
                    int take = int.MaxValue,
                    CancellationToken cancellationToken = default)
                    => (await this.mapper
                        .ProjectTo<TOutputModel>(this
                            .GetCarAdsQuery(carAdSpecification, dealerSpecification)
                            .Sort(carAdsSortOrder))
                        .ToListAsync(cancellationToken))
                        .Skip(skip)
                        .Take(take);

        public async Task<IEnumerable<CategoryOutputModel>> GetCategories(CancellationToken cancellationToken = default)
        {
            var categories = await this.mapper
               .ProjectTo<CategoryOutputModel>(this.Data.Categories)
               .ToDictionaryAsync(c=>c.Id, cancellationToken);

            var carAdsPerCategory = await this.AllAvailable()
                .GroupBy(c => c.Id)
                .Select(gr => new
                {
                    CategoryId = gr.Key,
                    TotalCarAds = gr.Count()
                }).ToListAsync(cancellationToken);

            carAdsPerCategory.ForEach(c => categories[c.CategoryId].TotalCarAds = c.TotalCarAds);

            return categories.Values;

        }

        public Task<Category> GetCategory(int categoryId, CancellationToken cancellationToken = default)
        {
            return this.Data.Categories.FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);
        }

        public Task<Manufacturer> GetManufacturer(string manufacturer, CancellationToken cancellationToken = default)
        {
            return this.Data.Manufacturers.FirstOrDefaultAsync(m => m.Name == manufacturer, cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var carAd = await this.Data.CarAds.FindAsync(id);

            if (carAd == null)
            {
                return false;
            }

            this.Data.CarAds.Remove(carAd);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<CarAd> Find(int id, CancellationToken cancellationToken = default)
            => await this
                .All()
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        public async Task<CarAdDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken)
        => await this.mapper
                .ProjectTo<CarAdDetailsOutputModel>(this
                    .AllAvailable()
                    .Where(c => c.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<int> Total(
            Specification<CarAd> carAdSpecification,
            Specification<Dealer> dealerSpecification,
            CancellationToken cancellationToken = default)
            => await this
                .GetCarAdsQuery(carAdSpecification, dealerSpecification)
                .CountAsync(cancellationToken);

        private IQueryable<CarAd> AllAvailable()
            => this
                .All()
                .Where(car => car.IsAvailable);

        private IQueryable<CarAd> GetCarAdsQuery(
            Specification<CarAd> carAdSpecification,
            Specification<Dealer> dealerSpecification)
            => this
                .Data
                .Dealers
                .Where(dealerSpecification)
                .SelectMany(d => d.CarAds)
                .Where(carAdSpecification);

    }
}
