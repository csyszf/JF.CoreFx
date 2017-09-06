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
        public Task PublishDomainEvent<T>(T @event) where T : IDomainEvent
        {
            var handlers = _serviceProvider.GetServices<IDomainEventHandler<T>>();
            foreach (var handler in handlers)
            {
                Task.Run(()=>handler.RecieveAsync(@event));
            }
            return Task.CompletedTask;
        }
    }
}
