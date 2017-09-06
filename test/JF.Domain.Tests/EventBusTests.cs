using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JF.Domain.Event;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace JF.Domain.Tests
{
    public class EventBusTests
    {

        [Fact]
        public async Task PublishDomainEvent()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IEventBus, EventBus>();
            var mockHandler = new Mock<DomainEventHandler<TestEvent>>();
            services.AddTransient<IDomainEventHandler<TestEvent>>(_ => mockHandler.Object);
            var sp = services.BuildServiceProvider();

            var eventBus = sp.GetRequiredService<IEventBus>();
            await eventBus.PublishDomainEvent(new TestEvent());

            mockHandler.Verify(_ => _.RecieveAsync(It.IsAny<TestEvent>()), Times.Once);
        }

        [Fact]
        public async Task PublishIDomainEvent()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IEventBus, EventBus>();
            var mockHandler = new Mock<DomainEventHandler<TestEvent>>();
            services.AddTransient<IDomainEventHandler<TestEvent>>(_ => mockHandler.Object);
            var sp = services.BuildServiceProvider();

            var eventBus = sp.GetRequiredService<IEventBus>();
            var @event = new TestEvent() as IDomainEvent;
            await eventBus.PublishDomainEvent(@event);

            mockHandler.Verify(_ => _.RecieveAsync(It.IsAny<TestEvent>()), Times.Once);
        }

        [Fact]
        public async Task PublishEventOfDomain()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IEventBus, EventBus>();
            var mockHandler = new Mock<DomainEventHandler<TestEvent>>();
            services.AddTransient<IDomainEventHandler<TestEvent>>(_ => mockHandler.Object);
            var sp = services.BuildServiceProvider();

            var eventBus = sp.GetRequiredService<IEventBus>();
            var @event = new TestEvent() as IEvent;
            await eventBus.PublishEvent(@event);

            mockHandler.Verify(_ => _.RecieveAsync(It.IsAny<TestEvent>()), Times.Once);
        }

        public class TestEvent : IDomainEvent
        {
        }

    }
}
