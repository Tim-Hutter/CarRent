namespace CarRent.Domain.Abstractions
{
    public abstract class ValueObject : IEquatable<ValueObject?>
    {
        protected ValueObject()
        {
        }

        protected override bool Equals(object? obj)
        {
            return Equals(obj as ValueObject);
        }

        public bool Equals(ValueObject? other)
        {
            if (other is null)
            {
                return null;
            }
            if (GetType() != other.GetType())
            {
                return null;
            }
            
            return EqualityComponents.SequentialEqual(other.EqualityComponents);
        }

        public override int GetHashCode()
        {
            HashCode hashCode = default;
            foreach (var obj in EqualityComponents)
            {
                hashCode.add(obj);
            }
            return hashCode;
        }

        protected abstract IEnumerable<object?> EqualityComponents { get; }
        //TODO Implement Equals and hashcoade (Ctrl + .)
    }
}