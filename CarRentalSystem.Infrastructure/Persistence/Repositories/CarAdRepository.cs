namespace CarRentalSystem.Infrastructure.Persistence.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Features.CarAds;
    using Application.Features.CarAds.Queries.Search;
    using AutoMapper;
    using CarRentalSystem.Infrastructure.Persistance;
    using Domain.Models.CarAds;
    using Microsoft.EntityFrameworkCore;

    internal class CarAdRepository : DataRepository<CarAd>, ICarAdRepository
    {
        private readonly IMapper mapper;

        public CarAdRepository(CarRentalDbContext db, IMapper mapper)
            : base(db)
        => this.mapper = mapper;

        public async Task<IEnumerable<CarAdListingModel>> GetCarAdListings(
            string? manufacturer = default,
            CancellationToken cancellationToken = default)
        {
            var query = this.AllAvailable();

            if (!string.IsNullOrWhiteSpace(manufacturer))
            {
                query = query
                    .Where(car => EF
                        .Functions
                        .Like(car.Manufacturer.Name, $"%{manufacturer}%"));
            }

            return await this.mapper
                .ProjectTo<CarAdListingModel>(query)
                .ToListAsync(cancellationToken);
        }

        public Task<Category> GetCategory(int categoryId, CancellationToken cancellationToken = default)
        {
            return this.Data.Categories.FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);
        }

        public Task<Manufacturer> GetManufacturer(string manufacturer, CancellationToken cancellationToken = default)
        {
            return this.Data.Manufacturers.FirstOrDefaultAsync(m => m.Name == manufacturer, cancellationToken);
        }

        public async Task<int> Total(CancellationToken cancellationToken = default)
            => await this
                .AllAvailable()
                .CountAsync(cancellationToken);

        private IQueryable<CarAd> AllAvailable()
            => this
                .All()
                .Where(car => car.IsAvailable);

    }
}
