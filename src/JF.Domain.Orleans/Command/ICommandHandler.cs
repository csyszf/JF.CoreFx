using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orleans;

namespace JF.Domain.Command
{
    public interface ICommandHandler<in TCommand, TResult> : ICommandHandler
        where TCommand : ICommand<TResult>
        where TResult : CommandResult
    {
        Task<TResult> HandleAsync(TCommand command);
    }

    public interface ICommandHandler<in TCommand>: ICommandHandler<TCommand, CommandResult>
        where TCommand : ICommand<CommandResult>
    {
    }

    public interface ICommandHandler: IGrainWithIntegerKey
    {

    }

}
