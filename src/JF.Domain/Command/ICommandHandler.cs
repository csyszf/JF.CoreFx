using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JF.Domain.Command
{
    public interface ICommandHandler<in TCommand,TResult>
        where TCommand: ICommand<TResult>
        where TResult: CommandResult
    {
        Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
    }

    public interface ICommandHandler<in TCommand>: ICommandHandler<TCommand, CommandResult> 
        where TCommand : ICommand<CommandResult>
    {
    }
}
