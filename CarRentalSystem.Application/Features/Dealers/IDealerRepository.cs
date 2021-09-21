using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Application.Features.Dealers.Common;
using CarRentalSystem.Application.Features.Dealers.GetDealers;
using CarRentalSystem.Domain.Models.Dealers;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Features.Dealers
{
    public interface IDealerRepository : IRepository<Dealer>
    {
        Task<Dealer> FindById(string userId, CancellationToken cancellationToken = default);
        Task<int> GetDealerId(string userId, CancellationToken cancellationToken = default);
        Task<DealerDetailsOutputModel> FindDealerById(int dealerId, CancellationToken cancellationToken = default);
        Task<bool> HasCarAd(int dealerId, int carAdId, CancellationToken cancellationToken = default);
        Task<DealerOutputModel> GetDetailsByCarId(int carAdId, CancellationToken cancellationToken = default);
    }
}
