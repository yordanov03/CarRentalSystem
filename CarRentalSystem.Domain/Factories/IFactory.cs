using CarRentalSystem.Domain.Common;

namespace CarRentalSystem.Domain.Factories
{
    public interface IFactory<out TEntity> where TEntity : IAggregateRoot
    {
        TEntity Build();
    }
}
