using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JF.Domain.Command
{
    public interface ICommandBus
    {
        Task<TCommandResult> SendAsync<TCommand, TCommandResult>(
            TCommand command,
            CancellationToken cancellationToken = default
            )
            where TCommand : ICommand
            where TCommandResult: CommandResult;

        Task<CommandResult> SendAsync<TCommand>(
            TCommand command,
            CancellationToken cancellationToken = default
            ) 
            where TCommand : ICommand;
    }
}
