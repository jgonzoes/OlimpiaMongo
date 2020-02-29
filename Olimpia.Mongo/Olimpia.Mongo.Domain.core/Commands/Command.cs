using Olimpia.Mongo.Domain.core.Events;
using System;

namespace Olimpia.Mongo.Domain.core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
