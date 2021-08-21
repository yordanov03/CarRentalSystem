using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Domain.Common;
using CarRentalSystem.Infrastructure.Persistance;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Infrastructure.Persistence.Repositories
{
    internal class DataRepository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        private readonly CarRentalDbContext db;

        public DataRepository(CarRentalDbContext db) => this.db = db;
        public IQueryable<TEntity> All() => this.db.Set<TEntity>();

        public Task<int> SaveChanges(CancellationToken cancelation = default)
       => this.db.SaveChangesAsync(cancelation);
    }
}
