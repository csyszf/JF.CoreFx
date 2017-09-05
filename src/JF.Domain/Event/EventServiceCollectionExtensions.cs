using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace JF.Domain.Event
{
    public static class EventServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainEvent<TEvent>(this IServiceCollection services, params Type[] handlerTypes)
            where TEvent: IDomainEvent
        {
            Type domainEventHandlerType = typeof(IDomainEventHandler<TEvent>);
            foreach (var handlerType in handlerTypes)
            {
                if (domainEventHandlerType.IsAssignableFrom(handlerType))
                {
                    services.AddTransient(domainEventHandlerType, handlerType);
                }
            }
            return services;
        }
    }
}
