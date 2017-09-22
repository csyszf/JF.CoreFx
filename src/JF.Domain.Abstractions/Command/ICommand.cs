using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JF.Domain.Command
{
    public interface ICommand<out TResult>
    {
    }

    public interface ICommand : ICommand<CommandResult>
    {
    }
}
