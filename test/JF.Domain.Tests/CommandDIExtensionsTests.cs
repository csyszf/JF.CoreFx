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
    public class CommandDIExtensionsTests
    {
        [Fact]
        public void ComplexHandlerDI()
        {
            var services = new ServiceCollection();
            services.AddCommand<TestCommandHandler>();
            var sp = services.BuildServiceProvider();

            Assert.IsType<TestCommandHandler>(sp.GetRequiredService<ICommandHandler<CommandA>>());
            Assert.IsType<TestCommandHandler>(sp.GetRequiredService<ICommandHandler<CommandB, StringResult>>());
        }
    }

    public class CommandA: ICommand<CommandResult> { }

    public class CommandB: ICommand<StringResult> { }

    public class StringResult : CommandResult<string>
    {
    }

    public class TestCommandHandler
        : ICommandHandler<CommandA>, ICommandHandler<CommandB, StringResult>
    {
        public Task<CommandResult> HandleAsync(CommandA command, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<StringResult> HandleAsync(CommandB command, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }


}
