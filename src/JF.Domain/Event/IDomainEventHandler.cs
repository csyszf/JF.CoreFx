﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Event
{
    public interface IDomainEventHandler<TEvent>: IDisposable where TEvent : IDomainEvent
    {
        Task RecieveAsync(TEvent @event);
    }
}
