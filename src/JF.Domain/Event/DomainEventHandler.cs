using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace JF.Domain.Event
{
    public abstract class DomainEventHandler<TEvent>: IDomainEventHandler<TEvent> where TEvent: IDomainEvent
    {
        public abstract Task RecieveAsync(TEvent @event);
    }
}
