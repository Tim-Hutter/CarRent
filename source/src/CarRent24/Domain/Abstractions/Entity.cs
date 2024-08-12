namespace CarRent.Domain.Abstractions
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> domainEvents = [];
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid id {get; private set;}

        public IReadOnlyList<IDomainEvent> domainEvents => _domainEvent;

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvent.Add(domainEvent);
        }

        //TODO Implement Equals and hashcoade (Ctrl + .)
    }
}