using CarRentalSystem.Domain.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Contracts
{
    public interface IRepository<in TEntity> where TEntity : IAggregateRoot
    {
        Task Save(TEntity entity, CancellationToken cancelation = default);
    }
}
