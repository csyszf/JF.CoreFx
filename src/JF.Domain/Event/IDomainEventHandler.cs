﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Event
{
    public interface IDomainEventHandler
    {
        Task RecieveAsync(IDomainEvent @event);
    }
}
