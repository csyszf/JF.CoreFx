using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JF.Domain.Command;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JF.Domain.Tests
{
    public class DIExtensionsTests
    {
        [Fact]
        public void ComplexHandlerDI()
        {
            var services = new ServiceCollection();
            services.AddCommand<TestCommandHandler>();
            var sp = services.BuildServiceProvider();

            Assert.IsType<TestCommandHandler>(sp.GetRequiredService<ICommandHandler<CommandA>>());
            Assert.IsType<TestCommandHandler>(sp.GetRequiredService<ICommandHandler<CommandB, string>>());
        }
    }

    public class CommandA: ICommand { }

    public class CommandB: ICommand<string> { }

    public class TestCommandHandler
        : ICommandHandler<CommandA>, ICommandHandler<CommandB, string>
    {
        public Task<CommandResult> HandleAsync(CommandA command, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<string> HandleAsync(CommandB command, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
