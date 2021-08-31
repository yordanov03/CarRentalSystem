using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Domain.Common;
using CarRentalSystem.Infrastructure.Persistance;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Infrastructure.Persistence.Repositories
{
    internal abstract class DataRepository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        private readonly CarRentalDbContext db;

        protected DataRepository(CarRentalDbContext db) => this.Data = db;

        protected CarRentalDbContext Data { get; }
        public IQueryable<TEntity> All() => this.db.Set<TEntity>();

    }
}
