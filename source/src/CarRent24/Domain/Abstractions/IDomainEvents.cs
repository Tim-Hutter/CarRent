namespace CarRent.Domain.Abstractions
{
    public interface IDomainEvent
    {
        IReadOnlyList<domainEvent> domainEvents { get; }
    }
}