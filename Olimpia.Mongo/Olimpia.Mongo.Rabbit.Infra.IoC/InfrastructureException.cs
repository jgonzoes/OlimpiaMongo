using System;

namespace Olimpia.Mongo.Rabbit.Infra.IoC
{
    public class InfrastructureException : Exception
    {
        internal InfrastructureException(string businessMessage)
            : base(businessMessage)
        {
        }
    }
}

