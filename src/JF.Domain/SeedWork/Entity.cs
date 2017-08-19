using JF.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace JF.Domain.SeedWork
{
    public abstract class Entity
    {
        private List<IEvent> _domainEvents;
        public List<IEvent> DomainEvents => _domainEvents;
        public void AddDomainEvent(IEvent eventItem)
        {
            _domainEvents = _domainEvents ?? new List<IEvent>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(IEvent eventItem)
        {
            if (_domainEvents is null) return;
            _domainEvents.Remove(eventItem);
        }
    }
}
