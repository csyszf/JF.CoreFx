using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace JF.Domain.Command
{
    public class CommandBus : ICommandBus
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public Task<R> SendAsync<T, R>(T command, CancellationToken cancellationToken = default) where T : ICommand<R>
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<T, R>>();
            return handler.HandleAsync(command, cancellationToken);
        }

        public Task<CommandResult> SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : ICommand
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<T>>();
            return handler.HandleAsync(command, cancellationToken);
        }
    }
}
