using Core.Domain.Events;

namespace Core.Domain.Entities
{
    public interface IBaseEntity<T>
    {
        T Id { get; }
        DateTime CreatedAt { get; }
        DateTime? UpdatedAt { get; }
        bool IsDeleted { get; }

        IReadOnlyCollection<DomainEvent> DomainEvents { get; }

        void MarkAsUpdated();
        void MarkAsDeleted();
        void AddDomainEvent(DomainEvent domainEvent);
        void ClearDomainEvents();
    }

    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        public T Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; protected set; }
        public bool IsDeleted { get; protected set; }

        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        private readonly List<DomainEvent> _domainEvents = new();

        public void MarkAsUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
            MarkAsUpdated();
        }

        public void AddDomainEvent(DomainEvent domainEvent)
        {
            if (!_domainEvents.Contains(domainEvent))
                _domainEvents.Add(domainEvent);
        }


        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
