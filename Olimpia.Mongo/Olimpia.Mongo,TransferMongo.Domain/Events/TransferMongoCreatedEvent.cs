﻿using Olimpia.Mongo.Domain.core.Events;

namespace Olimpia.Mongo_TransferMongo.Domain.Events
{
    public class TransferMongoCreatedEvent : Event
    {
        public int From { get; private set; }
        public int To { get; private set; }
        public decimal Amount { get; private set; }

        public TransferMongoCreatedEvent(int from, int to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}
