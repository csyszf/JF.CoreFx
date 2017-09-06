using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Event
{
    public interface IEventBus
    {
        Task PublishDomainEvent<T>(T @event) where T : IDomainEvent;
    }
}
