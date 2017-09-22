using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JF.Domain.Command
{
    public interface ICommandBus
    {
        Task<TResult> SendAsync<TCommand, TResult>(
            TCommand command,
            CancellationToken cancellationToken = default
            )
            where TCommand : ICommand<TResult>
            where TResult: CommandResult;

        Task<CommandResult> SendAsync<TCommand>(
            TCommand command,
            CancellationToken cancellationToken = default
            ) 
            where TCommand : ICommand<CommandResult>;
    }
}
