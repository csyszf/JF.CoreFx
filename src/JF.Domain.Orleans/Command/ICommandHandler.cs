using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orleans;

namespace JF.Domain.Command
{
    public interface ICommandHandler<in TCommand, TPayload> : ICommandHandler
        where TCommand : ICommand<CommandResult<TPayload>>
    {
        Task<CommandResult<TPayload>> HandleAsync(TCommand command);
    }

    public interface ICommandHandler<in TCommand>: ICommandHandler
        where TCommand : ICommand<CommandResult>
    {
        Task<CommandResult> HandleAsync(TCommand command);
    }

    public interface ICommandHandler: IGrainWithIntegerKey
    {

    }

}
