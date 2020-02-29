using Olimpia.Mongo.Domain.core.Commands;

namespace Olimpia.Mongo.Bankin.Domain.Commands
{
    public abstract class TransferCommand : Command
    {
        public int From { get; protected set; }
        public int To { get; protected set; }
        public decimal Amount { get; protected set; }
    }
}
