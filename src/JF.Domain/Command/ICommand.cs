using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JF.Domain.Command
{
    public interface ICommand<out R>
    {
    }

    public interface ICommand
    {
    }
}
