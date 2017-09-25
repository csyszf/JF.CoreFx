using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orleans;

namespace JF.Domain.Command
{
    public interface ICommandHandler<in TCommand, TCommandResult> : ICommandHandler
        where TCommand : ICommand
        where TCommandResult: CommandResult
    {
        Task<TCommandResult> HandleAsync(TCommand command);
    }

    public interface ICommandHandler<in TCommand>: ICommandHandler<TCommand, CommandResult>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler: IGrainWithIntegerKey
    {

    }

}
