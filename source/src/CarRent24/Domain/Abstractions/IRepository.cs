namespace CarRent.Domain.Abstractions
{
    public interface IRepository<TAggregate>
        where TAggragate : Entity, IAggragateRoot
    {
        TAggregate FindById(Guid id); //maybe monad

        void Add(TAggragate entity);

        void Remove(TAggragate entity);
    }
}