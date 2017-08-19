﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JF.Domain.Command
{
    public interface ICommandBus
    {
        Task<R> SendAsync<T, R>(
            T Command, 
            CancellationToken cancellationToken = default
            ) where T : ICommand<R>;

    }
}