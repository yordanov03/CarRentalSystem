using CarRentalSystem.Application.Features.Dealers;
using CarRentalSystem.Domain.Models.Dealers;
using CarRentalSystem.Infrastructure.Persistance;
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
    }
}
