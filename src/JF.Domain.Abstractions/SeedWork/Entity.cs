using JF.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace JF.Domain.SeedWork
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }
    }
}
