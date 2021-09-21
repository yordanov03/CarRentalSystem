using AutoMapper;
using CarRentalSystem.Application.Features.Dealers;
using CarRentalSystem.Application.Features.Dealers.Common;
using CarRentalSystem.Application.Features.Dealers.GetDealers;
using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models.Dealers;
using CarRentalSystem.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Infrastructure.Persistence.Repositories
{
    internal class DealerRpository : DataRepository<Dealer>, IDealerRepository
    {
        private readonly IMapper mapper;
        public DealerRpository(CarRentalDbContext db, IMapper mapper) : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<Dealer> FindById(string userId, CancellationToken cancellationToken = default)
        {
            var dealer = await this.Data.Users.Where(d => d.Id == userId).Select(d => d.Dealer).FirstOrDefaultAsync(cancellationToken);

            if (dealer == null)
            {
                throw new InvalidDealerException("This user is not a dealer.");
            }

            return dealer;

        }

        public async Task<bool> HasCarAd(int dealerId, int carAdId, CancellationToken cancellationToken = default)
           => await this
               .All()
               .Where(d => d.Id == dealerId)
               .AnyAsync(d => d.CarAds
                   .Any(c => c.Id == carAdId), cancellationToken);

        public Task<int> GetDealerId(
            string userId,
            CancellationToken cancellationToken = default)
            {
            int id;

            bool success = int.TryParse(userId, out id);
            if (!success)
            {
                throw new InvalidDealerException("No dealer with that id");
            }

            var dealerId = this.Data.Dealers.Where(d => d.Id == id).Select(d=>d.Id).FirstOrDefaultAsync(cancellationToken);

            return dealerId;
        }

        public async Task<DealerDetailsOutputModel> FindDealerById(int dealerId, CancellationToken cancellationToken = default)
        => await this.mapper
                .ProjectTo<DealerDetailsOutputModel>(this
                    .Data.Dealers
                    .Where(d => d.Id == dealerId))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<DealerOutputModel> GetDetailsByCarId(int carAdId, CancellationToken cancellationToken = default)
        => await this.mapper
            .ProjectTo<DealerDetailsOutputModel>
            (this.All()
            .Where(d => d.CarAds.Any(c => c.Id == carAdId)))
            .SingleOrDefaultAsync(cancellationToken);
    }
}
