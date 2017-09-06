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

            await CanTimeoutTask(Wait, 3000);
            Assert.Equal(handlers.Length, TestEvent.cnt);

            async Task CanTimeoutTask(Action action, int timeout)
            {
                var task1 = Task.Run(action);

                var task2 = Task.Delay(timeout);

                var firstTask = await Task.WhenAny(task1, task2);

                if (firstTask == task2)
                {
                    throw new TimeoutException();
                }
            }

            void Wait()
            {
                while (TestEvent.cnt != handlers.Length)
                { }
            }
        }

        class TestEvent : IDomainEvent
        {
            public static int cnt = 0;
        }

        class TestEventHandler : DomainEventHandler<TestEvent>
        {
            public TestEventHandler(IServiceScopeFactory scopeFactory) : base(scopeFactory)
            { }

            public override Task RecieveAsync(TestEvent @event)
            {
                Interlocked.Increment(ref TestEvent.cnt);
                return Task.CompletedTask;
            }
        }
    }
}
