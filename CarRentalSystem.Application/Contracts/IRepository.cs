using CarRentalSystem.Domain.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Contracts
{
    public interface IRepository<out TEntity> where TEntity : IAggregateRoot
    {
        IQueryable<TEntity> All();
        //Task<int> SaveChanges(CancellationToken cancelation = default);
    }
}
