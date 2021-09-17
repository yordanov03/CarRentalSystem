using AutoMapper;
using CarRentalSystem.Application.Features.Dealers;
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
            => this.mapper = mapper;

        public async Task<Dealer> FindById(string userId, CancellationToken cancellationToken = default)
        {
            var dealer = await this.Data
                .Users
                .Where(d => d.Id == userId)
                .Select(d => d.Dealer)
                .FirstOrDefaultAsync(cancellationToken);

            if (dealer == null)
            {
                throw new InvalidDealerException("This user is not a dealer.");
            }

            return dealer;

        }

        public async Task<Dealer> FindDealerById(int dealerId, CancellationToken cancellationToken = default)
        {
            var dealer = await this.Data
                .Dealers
                .Where(d => d.Id == dealerId).FirstOrDefaultAsync(cancellationToken);

            if (dealer == null)
            {
                throw new InvalidDealerException("This user is not a dealer.");
            }

            return dealer;
        }

    }
}
