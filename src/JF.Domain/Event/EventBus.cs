using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace JF.Domain.Event
{
    public class EventBus: IEventBus
    {
        private readonly IServiceProvider _serviceProvider;
        public EventBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }
        public Task PublishEvent(IEvent @event)
        {
            if(@event is IDomainEvent domainEvent)
            {
                return PublishDomainEvent(domainEvent);
            }
            return Task.CompletedTask;
        }
        public Task PublishDomainEvent(IDomainEvent @event)
        {
            var handlerInterface = typeof(IDomainEventHandler<>).MakeGenericType(@event.GetType());
            var handlers = _serviceProvider.GetServices(handlerInterface).Cast<IDomainEventHandler>();
            var tasks = handlers.Select(_ => _.RecieveAsync(@event)).ToArray();
            return Task.WhenAll(tasks);
        }
        public Task PublishDomainEvent<T>(T @event) where T : IDomainEvent
        {
            var handlers = _serviceProvider.GetServices<IDomainEventHandler<T>>();
            var tasks = handlers.Select(_ => _.RecieveAsync(@event)).ToArray();
            return Task.WhenAll(tasks);
        }
    }
}
