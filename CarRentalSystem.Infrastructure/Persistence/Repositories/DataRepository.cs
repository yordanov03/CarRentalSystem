﻿using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Domain.Common;
using CarRentalSystem.Infrastructure.Persistance;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Infrastructure.Persistence.Repositories
{
    internal abstract class DataRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        protected DataRepository(CarRentalDbContext db) => this.Data = db;

        protected CarRentalDbContext Data { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        public async Task Save(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            this.Data.Add(entity);

            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}
