using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Domain.Models.Dealers;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Features.Dealers
{
    public interface IDealerRepository : IRepository<Dealer>
    {
        //Task Save(Dealer dealer, CancellationToken cancellationToken = default);
        Task<Dealer> FindById(string userId, CancellationToken cancellationToken = default);
    }
}
