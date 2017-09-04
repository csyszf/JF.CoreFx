using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JF.Domain.Command
{
    public interface ICommandHandler<in T,R> where T: ICommand<R>
    {
        Task<R> HandleAsync(T command, CancellationToken cancellationToken = default);
    }

    public interface ICommandHandler<in T> where T : ICommand
    {
        Task<CommandResult> HandleAsync(T command, CancellationToken cancellationToken = default);
    }
}
