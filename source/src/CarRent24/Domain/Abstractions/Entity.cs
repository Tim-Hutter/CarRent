namespace CarRent.Domain.Abstractions
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid id {get; private set;}

        //TODO Implement Equals and hashcoade (Ctrl + .)
    }
}