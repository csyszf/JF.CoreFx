using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace JF.Domain.Event
{
    public abstract class DomainEventHandler<TEvent>: IDomainEventHandler<TEvent> where TEvent: IDomainEvent
    {
        private readonly IServiceScope _scope;
        private readonly IServiceProvider _provider;
        public DomainEventHandler(IServiceScopeFactory scopeFactory)
        {
            _provider = scopeFactory?.CreateScope()?.ServiceProvider ?? throw new ArgumentNullException(nameof(scopeFactory));
        }

        public abstract Task RecieveAsync(TEvent @event);

        public void Dispose()
        {
            _scope.Dispose();
        }

    }
}
