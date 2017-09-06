using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JF.Domain.Command;
using JF.Domain.Event;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JF.Domain.Tests
{
    public class EventDIExtensionsTests
    {
        [Fact]
        public void ComplexHandlerDI()
        {
            var services = new ServiceCollection();
            services.AddDomainEvent<TestEvent>(typeof(EventHandlerA), typeof(EventHandlerB));
            var sp = services.BuildServiceProvider();

            var handlers = sp.GetServices<IDomainEventHandler<TestEvent>>();
            var types = handlers.Select(_ => _.GetType());
            Assert.Contains(typeof(EventHandlerA), types);
            Assert.Contains(typeof(EventHandlerB), types);
        }
    }

    public class TestEvent: IDomainEvent { }


    public class EventHandlerA
        : DomainEventHandler<TestEvent>
    {
        public override Task RecieveAsync(TestEvent @event)
        {
            return Task.CompletedTask;
        }
    }

    public class EventHandlerB
    : DomainEventHandler<TestEvent>
    {
        public override Task RecieveAsync(TestEvent @event)
        {
            return Task.CompletedTask;
        }
    }

}
