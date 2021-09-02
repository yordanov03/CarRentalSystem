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
        public DealerRpository(CarRentalDbContext db) : base(db)
        {

        }
        public async Task Save(Dealer dealer, CancellationToken cancellationToken = default)
        {
            this.Data.Add(dealer);
            await this.Data.SaveChangesAsync(cancellationToken);

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
    }
}
