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
            var tasks = handlers.Select(h => h.RecieveAsync(@event));
            foreach (var task in tasks)
            {
                task.Start(TaskScheduler.Default);
            }
            return Task.CompletedTask;
        }
    }
}
