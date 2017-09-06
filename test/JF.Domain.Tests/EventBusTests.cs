using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JF.Domain.Event;
using Microsoft.Extensions.DependencyInjection;
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
            var handlers = new Type[] { typeof(TestEventHandler) };
            services.AddDomainEvent<TestEvent>(handlers);
            var sp = services.BuildServiceProvider();

            var eventBus = sp.GetRequiredService<IEventBus>();
            await eventBus.PublishDomainEvent(new TestEvent());

            Assert.Equal(handlers.Length, TestEvent.cnt);
        }

        class TestEvent : IDomainEvent
        {
            public static int cnt = 0;
        }

        class TestEventHandler : DomainEventHandler<TestEvent>
        {
            public override Task RecieveAsync(TestEvent @event)
            {
                Interlocked.Increment(ref TestEvent.cnt);
                return Task.CompletedTask;
            }
        }
    }
}
